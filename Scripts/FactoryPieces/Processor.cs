using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Processor : GridGameObject {

	public List<IOStreamDir> SetInputs;
	public List<IOStreamDir> SetOutputs;

	StreamModifier myModifier;
	public float multiplier;

	public override void Create()
	{
		StreamInputs = SetInputs;
		StreamOutputs = SetOutputs;

		myModifier = new StreamModifier (multiplier);
	}
	
	public override void ManageStream()
	{
		if (this.Stream.GetState == streamState.unprocessed) {
            this.Stream.GetState = streamState.processed;
			this.Stream.AddModifier = myModifier;
			this.PassStream ();
		} else {
			this.ChangeState = runningState.incorrectInput;
			//Destroy (this.Stream);
			return;
		}
	}



}
