using UnityEngine;
using System.Collections;

public class InitGridPieces
{


    public void PopulateGrid(Grid myGrid, Vector2[] harvestingPoints, Vector2[] gatheringPoints, Vector2[] blockage = null)
    {
        SpawnHarvestingPoints(myGrid, harvestingPoints);

        SpawnGatheringPoints(myGrid, gatheringPoints);

        SpawnBlockage(myGrid, blockage);
    }

    public void SpawnHarvestingPoints(Grid myGrid, Vector2[] locations)
    {
        for (int point = 0; point < locations.Length; point++)
        {
            GridPiece curPiece = myGrid.getGridPiece(Mathf.FloorToInt(locations[point].x), Mathf.FloorToInt(locations[point].y));
            curPiece.PlaceGridPiece(PrefabLib.getLibrary.Harvester);
        
        }

    }

    public void SpawnGatheringPoints(Grid myGrid, Vector2[] locations)
    {
        for (int point = 0; point < locations.Length; point++)
        {
            GridPiece curPiece = myGrid.getGridPiece(Mathf.FloorToInt(locations[point].x), Mathf.FloorToInt(locations[point].y));
            curPiece.PlaceGridPiece(PrefabLib.getLibrary.Gatherer);
       
        }


    }

    public void SpawnBlockage(Grid myGrid, Vector2[] locations)
    {
        for (int point = 0; point < locations.Length; point++)
        {
            GridPiece curPiece = myGrid.getGridPiece(Mathf.FloorToInt(locations[point].x), Mathf.FloorToInt(locations[point].y));
            curPiece.PlaceGridPiece(PrefabLib.getLibrary.Blockage);
      
        }
    }



}
