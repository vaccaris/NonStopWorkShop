using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    private static ToolTip myTT;

    public Text tT;

    public Image Default;

    void Awake()
    {
        myTT = this.gameObject.GetComponent<ToolTip>();
        this.gameObject.SetActive(false);
    }

    public static ToolTip getTT {
        get
        {
            if(myTT == null)
            {
                if(FindObjectOfType<ToolTip>() != null)
                {
                    myTT = FindObjectOfType<ToolTip>();
                    return myTT;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return myTT;
            }

        }
    }

    public void setTT(string input)
    {
        if (!this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(true);
        }
        StopAllCoroutines();
        tT.text = input;
     //   Default.gameObject.SetActive(false);
        tT.gameObject.SetActive(true);
        StartCoroutine("disableTT");

    }

    IEnumerator disableTT()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);

    }

	
}
