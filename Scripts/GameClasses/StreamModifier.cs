using UnityEngine;
using System.Collections;

public class StreamModifier{

    float streamMultiplier = 1f;

	public StreamModifier(float multiplyBy){
		streamMultiplier = multiplyBy;
	}


	public ResourceStream Modify(ResourceStream ModifyStream){
		ResourceStream StreamToModify = ModifyStream;

		ModifyStream.currentValue += streamMultiplier;

		return StreamToModify;
	}


	
}
