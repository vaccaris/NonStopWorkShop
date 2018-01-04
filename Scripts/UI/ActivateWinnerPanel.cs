using UnityEngine;
using System.Collections;

public class ActivateWinnerPanel : MonoBehaviour {
    public GameObject Panel, NextLevel, PrevLevel, FirstLevel;

    private static ActivateWinnerPanel myPanel;

    public static ActivateWinnerPanel getPanel
    {
        get
        {
            if(myPanel != null)
            {
                return myPanel;
            }
            else
            {
                return null;
            }
        }
    }

    void Awake()
    {
        myPanel = this.gameObject.GetComponent<ActivateWinnerPanel>();
    }

    public void ActivatePanel()
    {
        int level = NextLevelTemp.getLevel.currentLevel;
        int maxLevel = NextLevelTemp.getLevel.maxLevels;

        Panel.gameObject.SetActive(true);

        if(level != maxLevel)
        {
            NextLevel.gameObject.SetActive(true);
        }
        else
        {
            NextLevel.gameObject.SetActive(false);
        }

        if(level != 0)
        {
            PrevLevel.SetActive(true);
        }
        else
        {
            PrevLevel.SetActive(false);
        }

        FirstLevel.SetActive(true);
    }

    public void DeactivatePanel()
    {
        Panel.gameObject.SetActive(false);
    }


	
}
