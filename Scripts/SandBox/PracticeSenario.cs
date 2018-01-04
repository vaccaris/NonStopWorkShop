
using UnityEngine;
using System.Collections;

//this is an example of how to build a senario, later ideally we will have some editor tools that makes instances of this in an easier to use visual format
public class PracticeSenario : MonoBehaviour
{

    public int width, depth;

    float offset = 1f;

    [Tooltip("Set these for where gathering nodes will be, the grid builds down, so 0,0 is the top left where maxX/maxY is the bottom right")]
    public Vector2[] harvestingPoints;

    [Tooltip("Set these for where gathering nodes will be, the grid builds down, so 0,0 is the top left where maxX/maxY is the bottom right")]
    public Vector2[] OutPutPos;

    public Vector2[] blockagePos;

    public float startingReource;

    public void Init()
    {
        GameObject grid = new GameObject();
        Grid myGrid = grid.AddComponent<Grid>().BuildGrid(grid, depth, width, offset);
        InitGridPieces myInit = new InitGridPieces();
        myInit.PopulateGrid(myGrid, harvestingPoints, OutPutPos, blockagePos);
        ResourceManager.rManager.initReource(startingReource);

    }


}

/*modified code:
	This,
	gridPiece,
	prefabLib,
	initgridpieces
*/
