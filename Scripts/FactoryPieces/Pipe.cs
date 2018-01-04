using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pipe : GridGameObject {

    public List<IOStreamDir> SetInputs;
    public List<IOStreamDir> SetOutputs;

	public streamState whatIprocess;

    

    public override void Create()
    {
        if(myAnimator == null)
        {
            myAnimator = this.gameObject.GetComponentInChildren<AnimationSetting>();
        }
        //base.Init();
        StreamInputs = SetInputs;
        StreamOutputs = SetOutputs;
		this.StreamprocessingType = whatIprocess;
      
    }

    public override void ManageStream()
    {
		if (this.Stream.GetState != this.StreamprocessingType) {
			StreamPool.returnStream (this.Stream);
			this.ChangeState = runningState.incorrectInput;
			return;
		}

      //  myAnimator.setAnimState(this);
        this.PassStream();
    }



}
