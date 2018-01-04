using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is my Grid object, it will be spawned and hold all of our grid pieces, and in turn hold pretty much everything


public class Grid : MonoBehaviour {

	private static Grid _gridInstace; //This is just the instance of the grid for accessing this from other places, however this should not be needed often
                                        //as the grid is being manually passed and handled to what needs it

	GridPiece[,] myGridPieces; //This is our grid itself, this will be filled with PopulateGrid, each gridpiece holds the info about each grid square

    GameObject myGrid;

	public List<GridPiece> myGridPieceComponenets = new List<GridPiece>(); //this list holds all of our gridpeices, this should hold all of the same stuff
    //as the multidimensional array above, but this list will just let us easily iterate over all of our objects if needed

	
	// Use this for initialization
    
    public Grid(int depth,int width, float offset) //this is how we spawn a grid
    {
     GameObject myGrid = new GameObject(); //spawn a gameobject
        myGrid.transform.name = "Grid"; //name it
        Grid myGridComp = myGrid.AddComponent<Grid>(); //add a grid componenet
        myGridComp.SetGrid(); //run set grid, which sets the singleton instance 
        myGridPieceComponenets = new List<GridPiece>() ;
        myGridComp.PopulateGrid(depth, width, offset); //then we populate the grid with gridpeices
        Vector3 newPos = new Vector3(offset * width * -0.5f, 0, offset * depth * 0.5f); //this is just offsetting the grid so the center of the grid is always 0,0,0
        myGrid.transform.position = newPos; //offset
      
    }

	public Grid BuildGrid(GameObject myGrid, int depth,int width, float offset) //this is how we spawn a grid
	{
		//GameObject myGrid = new GameObject(); //spawn a gameobject
		myGrid.transform.name = "Grid"; //name it
		//Grid myGridComp = myGrid.AddComponent<Grid>(); //add a grid componenet
		Grid myGridComp = this;
		myGridComp.SetGrid(); //run set grid, which sets the singleton instance 
		myGridPieceComponenets = new List<GridPiece>() ;
		myGridComp.PopulateGrid(depth, width, offset); //then we populate the grid with gridpeices
		Vector3 newPos = new Vector3(offset * width * -0.5f, 0, offset * depth * 0.5f); //this is just offsetting the grid so the center of the grid is always 0,0,0
		myGrid.transform.position = newPos; //offset
		return myGridComp;
	}

    public void AddToGrid(GridPiece thingToAdd)
    {
        if(myGridPieceComponenets == null)
        {
       
            myGridPieceComponenets = new List<GridPiece>();
        }
        myGridPieceComponenets.Add(thingToAdd);


    }




	public void SetGrid () { //set the grid as the grid singleton, if we already have a grid, make it null. We may need to remember to set this to null when we load out of the screen
                            //or we may try to access old grids

		if (_gridInstace == null) {
			_gridInstace = this;
		} else {
            Debug.LogError("trying to build a grid when we already have one"); //catch for errors
			Destroy(this.gameObject);
		}

	}


	public static Grid GetGrid{ //this just returns the grid instance, if we try to get the grid but haven't made one, throw an error

        get
        {
            if (_gridInstace == null)
            {
             //   Debug.LogError("Don't forget to run set Grid after creating it");
                return null;
            }

            return _gridInstace;
        }
	}

    public void DestroyGrid()
    {
        myGridPieceComponenets.Clear();
        _gridInstace = null;
        myGrid = null;
        Destroy(this.gameObject);

    }


	public void PopulateGrid(int height, int width,float offset){ //this populates the grid, this is the meat and potatoes of this script

		myGridPieces = new GridPiece[height, width]; //first we make a multidimensional array that is the width and depth of the grid, which we fill as we spawn

		for (int gridY = 0; gridY < height; gridY++) { //for each row(depth)
			GameObject myParent = new GameObject(); //make a row object
			myParent.transform.SetParent(this.transform); //set it's parent as the grid
			myParent.transform.name = "Row" + gridY.ToString(); //name it a row + the row number we are on
			for (int gridX = 0; gridX < width; gridX++) { //for each row, for each width in that row
                GameObject workingGO = new GameObject(); //make an empty object
                GridPiece thisPiece = workingGO.AddComponent<GridPiece>(); //add a gridpiece component to it
             
                // myGridPieceComponenets.Add(thisPiece);
                myGridPieces[gridY, gridX] = thisPiece; //set the variable of this position in the multidimensional array to this 
               
            //    myGridPieceComponenets.Add(myGridPieces[gridY, gridX]);
                workingGO.transform.SetParent(myParent.transform); //set the parent of this as the row it is in
                workingGO.transform.position = new Vector3(gridX * offset, 0f, gridY * offset * -1f); //offset the gridpiece in X and Y, multiplied by offset (we could move the row(parent object) in the Y and then only change the local transform of this object, but I like this more
                workingGO.transform.name = "GridPiece " + gridX.ToString(); //name the object for which position it is in the X	
				thisPiece.Init(PrefabLib.getLibrary.GetGridPeice,gridY,gridX); //Initilize the gridpiece, we feed in our gridpeice base object from our prefab library
                AddToGrid(thisPiece);
                //thisPiece.myColor = new Color(gridX * 0.1f, 0.2f, gridY * 0.1f); //right now im just changing the color for testing
				//myGridPieceComponenets.Add(thisPiece);
			}
            
		}
	}


    /*
    public bool hasNeighbor(int xPos, int yPos)
    {
        bool returnBool = false;
        if(((xPos > 0)&&(xPos < myGridPieces.GetLength(1))) && ((yPos > 0)&& (yPos < myGridPieces.GetLength(0)))){
            returnBool = true;
        }
        else
        {
            returnBool = false;
        }
        return returnBool;
    }
    */

    public GridPiece getGridPiece(int xPos, int yPos)
    {
        GridPiece returnPiece = null;
         if (((xPos >= 0) && (xPos < myGridPieces.GetLength(1))) && ((yPos >= 0) && (yPos < myGridPieces.GetLength(0))))
         {
        
            returnPiece = myGridPieces[yPos, xPos];

        }
        return returnPiece;
    }

	

}
