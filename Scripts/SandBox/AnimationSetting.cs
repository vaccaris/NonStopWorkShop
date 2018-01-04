using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AnimationSetting : MonoBehaviour {

    GridGameObject AnimStateCont;

    public Renderer[] gooCubes;

    public Material[] gooMats;

    public Animator myAnimator;

    

	// Use this for initialization
	void Start () {
	    AnimStateCont = GetComponent<GridGameObject>();
        myAnimator = gameObject.GetComponentInChildren<Animator>();

    }
	
	// Update is called once per frame
	 void FixedUpdate() {
        //Debug.Log(AnimStateCont.animState);

        if (myAnimator != null)
        {
            myAnimator.SetInteger("AnimState", (int)AnimStateCont.animState);
            // Debug.Log(myAnimator.GetInteger("AnimState") + this.transform.name);
            foreach (Renderer gooCube in gooCubes)
            {
                gooCube.material = gooMats[(int)AnimStateCont.animColor];

            }
        }

    }
}
