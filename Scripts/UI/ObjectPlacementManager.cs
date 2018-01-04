using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectPlacementManager : MonoBehaviour {

    GameObject ObjToSpawn = null;

    GridGameObject editObj;

    public RectTransform editPanel;
    EventSystem es;

    void Start()
    {
        es = FindObjectOfType<EventSystem>();
    }


    public void SetObject(GameObject workingObj)
    {
       ObjToSpawn = workingObj;
        if(ObjToSpawn.GetComponent<Description>() != null)
        {
            ToolTip.getTT.setTT(ObjToSpawn.GetComponent<Description>().myDescription);
        }

        if (editPanel.gameObject.activeInHierarchy)
        {
            editPanel.gameObject.SetActive(false);
        }

    }

    public void DeleteObjects()
    {
        ObjToSpawn = null;
   

    }


    void Update()
    {
#if UNITY_EDITOR
        ManageInput();
#endif
        ManageTouch();

    }

    void ManageTouch()
    {
        if (RunFactory.run)
        {
            return;
        }

        for (int touchi = 0; touchi < Input.touchCount; touchi++)
        // if(Input.touchCount > 0)      
        {
            if ((Input.GetTouch(touchi).phase == TouchPhase.Began))
            // if(true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(touchi).position);
                RaycastHit hit;


                if (es.IsPointerOverGameObject(touchi))
                {
                    return;
                }

                if (Physics.Raycast(ray, out hit))
                {
                    //  if (!(hit.transform is RectTransform))
                    // {
                    //Debug.Log(hit.transform.name);
                    if (hit.transform.parent.transform.GetComponent<GridPiece>() != null)
                    {
                        if ((hit.transform.parent.transform.GetComponent<GridPiece>().GridObj != null) && hit.transform.parent.transform.GetComponent<GridPiece>().GridObj.gameObject.GetComponent<Description>() != null)
                        {
                            ToolTip.getTT.setTT(hit.transform.parent.transform.GetComponent<GridPiece>().GridObj.gameObject.GetComponent<Description>().myDescription);
                        }
                        if (editObj != null)
                        {
                            editPanel.gameObject.SetActive(false);
                            editObj = null;
                        }

                        if (ObjToSpawn != null && !hit.transform.parent.transform.GetComponent<GridPiece>().hasGridObject && (ObjToSpawn.GetComponent<GridGameObject>().buildCost <= ResourceManager.rManager.curResource))
                        {
                            ResourceManager.rManager.curResource -= ObjToSpawn.GetComponent<GridGameObject>().buildCost;


                                hit.transform.parent.transform.GetComponent<GridPiece>().PlaceGridPiece(ObjToSpawn);
                              //  ObjToSpawn = null;
                            }
                            else
                            {
                                if (hit.transform.parent.transform.GetComponent<GridPiece>().hasGridObject && hit.transform.parent.GetComponent<GridPiece>().isEditable)
                                {
                                    editObj = hit.transform.parent.transform.GetComponent<GridPiece>().GridObj;
                                    EditObj();
                                }
                            }
                        
                    
                    }
                }
            }
        }
        //  }


    }


    void ManageInput()
    {
        if (RunFactory.run)
        {
            return;
        }

        if ((Input.GetMouseButtonDown(0)))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           

            if (es.IsPointerOverGameObject())
            {
                return;
            }

            if (Physics.Raycast(ray, out hit))
            {
                //  if (!(hit.transform is RectTransform))
                // {
               // Debug.Log(hit.transform.name);
                    if (hit.transform.parent.transform.GetComponent<GridPiece>() != null)
                    {
                    if ((hit.transform.parent.transform.GetComponent<GridPiece>().GridObj != null)&& hit.transform.parent.transform.GetComponent<GridPiece>().GridObj.gameObject.GetComponent<Description>() != null)
                    {
                        ToolTip.getTT.setTT(hit.transform.parent.transform.GetComponent<GridPiece>().GridObj.gameObject.GetComponent<Description>().myDescription);
                    }

                    //       if (editObj == null)
                    if (editObj != null)
                    {
                        editPanel.gameObject.SetActive(false);
                        editObj = null;
                    }
                    
                            if (ObjToSpawn != null && !hit.transform.parent.transform.GetComponent<GridPiece>().hasGridObject && (ObjToSpawn.GetComponent<GridGameObject>().buildCost <= ResourceManager.rManager.curResource))
                            {
                                ResourceManager.rManager.curResource -= ObjToSpawn.GetComponent<GridGameObject>().buildCost;
                                
                                hit.transform.parent.transform.GetComponent<GridPiece>().PlaceGridPiece(ObjToSpawn);
                             //   ObjToSpawn = null;
                            }
                            else
                            {
                                if (hit.transform.parent.transform.GetComponent<GridPiece>().hasGridObject && hit.transform.parent.GetComponent<GridPiece>().isEditable)
                                {
                                    editObj = hit.transform.parent.transform.GetComponent<GridPiece>().GridObj;
                                    EditObj();
                                }
                            }
                     //   }
    //                    else
    //                    {
   //                         editPanel.gameObject.SetActive(false);
    //                        editObj = null;
   //                     }
                 //   }
                }
            }
        }
    }

    void EditObj()
    {
       
        editPanel.anchoredPosition = Camera.main.WorldToScreenPoint(editObj.transform.position);
        editPanel.gameObject.SetActive(true);
    }

    public void Rotate(int dir)
    {
        if(editObj != null)
        {
            editObj.Rotate(dir);
        }
    }

    public void DeleteObj()
    {
        if(editObj != null)
        {
            editObj.SetMyPiece.DeleteGridObj();
            editPanel.gameObject.SetActive(false);

        }

    }

    




}
