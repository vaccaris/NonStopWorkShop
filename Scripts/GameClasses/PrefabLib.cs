using UnityEngine;
using System.Collections;

public class PrefabLib : MonoBehaviour {
    private static PrefabLib myLibrary;
    public GameObject myGridPeice;
    public GameObject Harvester;
    public GameObject Gatherer;  
    public GameObject Blockage;
    void Awake(){
		if (myLibrary == null) {
			myLibrary = this.gameObject.GetComponent<PrefabLib> ();
		} else {
			Destroy(this.gameObject);
		}
	}
    public static PrefabLib getLibrary
    {
        get
        {
            if (myLibrary == null)
            {
                myLibrary = FindObjectOfType<PrefabLib>();
                return myLibrary;
            }
            if (myLibrary == null)
            {
                Debug.LogError("an object in the scene is looking for the prefab library but it is not in the scene");
                return null;
            }
            else {
                return myLibrary;
            }
        }
    }

    public GameObject GetHarvester
    {
        get { return Harvester; }
    }

    public GameObject GetGatherer
    {
        get { return Gatherer; }
    }

    public GameObject GetGridPeice
    {
        get { return myGridPeice; }
    }

    public GameObject GetBlockage
    {
        get { return Blockage; }
    }



}
