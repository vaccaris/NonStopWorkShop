using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RunFactory : MonoBehaviour {

    public static int myResource = 0;
    public int myCurScore;

    public Text myScore;

    public static bool run = false;

    List<GridPiece> ActiveObjects = new List<GridPiece>();
    List<GatheringNode> myGatherers = new List<GatheringNode>();

    public GameObject editingButtons;

    public Text RunButton;

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Destroy(Grid.GetGrid.gameObject);
            if(Grid.GetGrid != null)
            {
                Grid.GetGrid.DestroyGrid();
            }
        }

         myScore.text = "$" + ResourceManager.rManager.curResource;
       // myCurScore = myResource;
	}
    
    

    public void InitAll()
    {
        ActiveObjects.Clear();
        myGatherers.Clear();
        Grid myGrid = Grid.GetGrid;
        for (int gridpeice = 0; gridpeice < myGrid.myGridPieceComponenets.Count; gridpeice++)
        {
            myGrid.myGridPieceComponenets[gridpeice].RunMyPiece();
            if(myGrid.myGridPieceComponenets[gridpeice].GridObj is HarvestingNode)
            {
                ActiveObjects.Add(myGrid.myGridPieceComponenets[gridpeice]);
            }else if(myGrid.myGridPieceComponenets[gridpeice].GridObj is GatheringNode)
            {
                myGatherers.Add(myGrid.myGridPieceComponenets[gridpeice].GridObj as GatheringNode);
            }
        }

    }

    public void StopRunning()
    {

        myResource = 0;
        Grid myGrid = Grid.GetGrid;
        for (int gridpeice = 0; gridpeice < myGrid.myGridPieceComponenets.Count; gridpeice++)
        {
            if (myGrid.myGridPieceComponenets[gridpeice].isEditable)
            {
                myGrid.myGridPieceComponenets[gridpeice].DeleteGridObj();
            }

        }
        StopAllCoroutines();
        run = false;

    }

    public void Run()
    {
        
        run = !run;
        if (run)
        {
            
            editingButtons.SetActive(false);
            RunButton.text = "Edit";
            InitAll();
            StartCoroutine("RunOnLoop");
            CheckWin();
          
        }
        else
        {
            
            TurnOff();
        }
    }

    void CheckWin()
    {
        Debug.Log(myGatherers.Count);
        for (int gatherer = 0; gatherer < myGatherers.Count; gatherer++)
        {
            Debug.Log(myGatherers[gatherer].CheckRecivingStream);
            if (!myGatherers[gatherer].CheckRecivingStream)
            {
               
                return;
            }

        }

        ActivateWinnerPanel.getPanel.ActivatePanel();

    }


    public void TurnOff()
    {
        RunButton.text = "Run";
        editingButtons.SetActive(true);
        ActivateWinnerPanel.getPanel.DeactivatePanel();
        StopAllCoroutines();
        run = false;

        Grid myGrid = Grid.GetGrid;
        for (int gridpeice = 0; gridpeice < myGrid.myGridPieceComponenets.Count; gridpeice++)
        {
            if (myGrid.myGridPieceComponenets[gridpeice].hasGridObject)
            {
                myGrid.myGridPieceComponenets[gridpeice].GridObj.StopRunning();
            }
        }
      //  Debug.Log("turn off");


    }


    IEnumerator RunOnLoop()
    {
        yield return new WaitForSeconds(1f);
        while (run)
        {
          
            Grid myGrid = Grid.GetGrid;
            for (int gridpeice = 0; gridpeice < ActiveObjects.Count; gridpeice++)
            {
                ActiveObjects[gridpeice].StartEngine();
               

            }
            yield return new WaitForSeconds(1f);
        }
        
    }


}
