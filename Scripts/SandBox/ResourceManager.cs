using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    private static ResourceManager myMan;

    float currentResource;

    //resourceCosts

  //  public float pipeCost = 50f, proccesorCost = 70f, harvesterCost = 100f, gathererCost = 200f, boosterCost = 350f, combinerCost = 200f;


    void Awake()
    {
        myMan = this.gameObject.GetComponent<ResourceManager>();
    }

    public void initReource(float start)
    {
        currentResource = start;
    }


    public float curResource {
        get
        {
            return currentResource;
        }
        set
        {
            currentResource = value;
        }

    }
	
  

    public static ResourceManager rManager
    {
        get
        {
            if(myMan == null)
            {
                myMan = FindObjectOfType<ResourceManager>();
            }
            if(myMan == null)
            {
                myMan = Camera.main.gameObject.AddComponent<ResourceManager>();
                return myMan;
            }
            else
            {
                return myMan;
            }
        }
    }

}
