using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NextLevelTemp : MonoBehaviour {

    private static NextLevelTemp levelThingy;

    public List<GameObject> myLevels = new List<GameObject>();

    int curLevel = 0;

    void Start()
    {
        GoToFirstLevel();
        curLevel = 0;
    }

    public static NextLevelTemp getLevel {
        get { return levelThingy; }
    }

    public int currentLevel
    {
        get { return curLevel; }
    }

    public int maxLevels
    {
        get { return (myLevels.Count - 1); }
    }

    void Awake()
    {
        levelThingy = this;
    }


    public void GoToFirstLevel()
    {
        UnloadGrid();
        PracticeSenario senario = myLevels[0].GetComponent<PracticeSenario>();
        senario.Init();
        curLevel = 0;

    }

    public void GoToNextLevel()
    {
        if (curLevel < myLevels.Count - 1)
        {
            UnloadGrid();
            curLevel++;       
            PracticeSenario senario = myLevels[curLevel].GetComponent<PracticeSenario>();
            senario.Init();
        }

    }

    public void GoToPreviousLevel()
    {
        if (curLevel > 0)
        {
            UnloadGrid();
            curLevel--;
            PracticeSenario senario = myLevels[curLevel].GetComponent<PracticeSenario>();
            senario.Init();
        }

    }

    public void UnloadGrid()
    {
        if (Grid.GetGrid != null)
        {
            Grid.GetGrid.DestroyGrid();
            RunFactory.myResource = 0;
        }
    }

   







	


}
