using UnityEngine;
using System.Collections;

public enum NeighborDir
{
    top,
    right,
    bottom,
    left
}


public class GridPiece : MonoBehaviour {
	
	Grid myGrid;

   

    public int wPos, hPos;

    private GridGameObject myGridObject = null;

    

    public GridPiece()
    {

    }

	public void Init(GameObject gridPieceBase, int yPos, int xPos){
		GameObject gridPeiceThingy = Instantiate (gridPieceBase, this.transform.position, Quaternion.identity, this.transform) as GameObject;
        wPos = xPos;
        hPos = yPos;
        myGrid = Grid.GetGrid;
	}



    public GridGameObject GridObj
    {
        get { return myGridObject; }
        set { myGridObject = value; }
    }

    public bool hasGridObject
    {
        get { return (myGridObject != null); }
    }

  

    public bool isEditable
    {
        get
        {
            if (!hasGridObject)
            {
                return false;
            }
            else if (myGridObject.isEditable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

	public GridGameObject GetNeighbor(IOStreamDir dirToCheck)
    {
        GridGameObject returnObj = null;
        switch (dirToCheck)
        {
            case IOStreamDir.Top:
                //  bool hasNeighbor = myGrid.hasNeighbor(wPos, hPos + 1);
                if (myGrid.getGridPiece(wPos, hPos - 1) != null)
                 
                {
                    if (myGrid.getGridPiece(wPos, hPos - 1).hasGridObject)
                    {
                        

                        returnObj = myGrid.getGridPiece(wPos, hPos - 1).GridObj;
                        if (returnObj.StreamInputs.Contains(IOStreamDir.Bottom))
                        {

                        }
                        else
                        {
                            returnObj = null;
                        }

                    }
                }
                break;
            case IOStreamDir.Right:
                if (myGrid.getGridPiece(wPos+1, hPos) != null)
                {
                    
                    if (myGrid.getGridPiece(wPos+1, hPos).hasGridObject)
                    {
                        returnObj = myGrid.getGridPiece(wPos+1, hPos).GridObj;
                        if (returnObj.StreamInputs.Contains(IOStreamDir.Left))
                        {

                        }
                        else
                        {
                            returnObj = null;
                        }
                    }
                }          
                break;
            case IOStreamDir.Bottom:
                if (myGrid.getGridPiece(wPos, hPos + 1) != null)
                {
                    if (myGrid.getGridPiece(wPos, hPos + 1).hasGridObject)
                    {
                        returnObj = myGrid.getGridPiece(wPos, hPos +1).GridObj;
                        if (returnObj.StreamInputs.Contains(IOStreamDir.Top))
                        {

                        }
                        else
                        {
                            returnObj = null;
                        }
                    }
                }
                break;
            case IOStreamDir.Left:
                if (myGrid.getGridPiece(wPos-1, hPos) != null)
                {
                    if (myGrid.getGridPiece(wPos-1, hPos).hasGridObject)
                    {
                        returnObj = myGrid.getGridPiece(wPos-1, hPos).GridObj;
                        if (returnObj.StreamInputs.Contains(IOStreamDir.Right))
                        {

                        }
                        else
                        {
                            returnObj = null;
                        }
                    }
                }
                break;
            default:
                Debug.LogError("Cannot currently support passing :" + dirToCheck);
                break;
        }

        return returnObj;
    }

    public void RunMyPiece()
    {
        if(myGridObject != null)
        {
            myGridObject.Init();
            
        }

    }

    public void StartEngine()
    {
        if(myGridObject != null)
        {
            myGridObject.RunOnAwake();
        }

    }

    public void DeleteGridObj()
    {
        if (myGridObject != null)
        {

            GameObject DeleteMe = myGridObject.gameObject;
            ResourceManager.rManager.curResource += myGridObject.buildCost;
            myGridObject.StopNeighbors();
            Destroy(DeleteMe);
            myGridObject = null;
        }
    }

    public void PlaceGridPiece(GameObject goToPlace)
    {
        if (myGridObject == null)
        {
            GameObject newObj = (GameObject)(Instantiate(goToPlace, this.transform.position, Quaternion.identity, this.transform));
            myGridObject = newObj.GetComponent<GridGameObject>();
            myGridObject.SetMyPiece = this;
            myGridObject.Create();
            myGridObject.Init();
        }
    }





}
