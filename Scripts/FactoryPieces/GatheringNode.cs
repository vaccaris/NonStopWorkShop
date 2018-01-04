using UnityEngine;
using System.Collections;

public class GatheringNode : GridGameObject {

   // public float ResourceGenerationValue;

	public streamState requiredStreamType = streamState.processed;

    public bool isRecivingStream;

    public override void Init()
    {
        isRecivingStream = false;
    }

    public override void Create()
    {
      //  base.Init();
		this.StreamprocessingType = requiredStreamType;
        this.SetAllStreamsAsInput();
      
    }

    public override void ManageStream()
    {
		if (this.Stream.GetState != this.StreamprocessingType) {
			StreamPool.returnStream (this.Stream);
			this.ChangeState = runningState.incorrectInput;
			return;
		}


        //  base.ManageStream();
        isRecivingStream = true;
        ResourceStream myStream = this.Stream;
        float myStreamValue = myStream.GetStreamValue();
        ResourceManager.rManager.curResource += myStreamValue;
		StreamPool.returnStream (this.Stream);
		//Destroy (myStream); //This is temp until I set up object pooling
		// Debug.LogError("Should be better");
            
        

    }

    public bool CheckRecivingStream
    {
        get { return isRecivingStream; }
    }




}
