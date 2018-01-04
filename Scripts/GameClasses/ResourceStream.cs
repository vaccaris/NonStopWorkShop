using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum streamColor
{
	notSet,
    red,
    blue,
    green
}

public enum streamState
{
	unchanged,
    unprocessed,
    processed
}


public class ResourceStream{
    List<StreamModifier> myModifiers = new List<StreamModifier>();

	streamColor myColor = streamColor.notSet;

	streamState myState = streamState.unchanged;

    float startValue = 0f;

	float finalValue;

    public ResourceStream(float InitialValue, streamColor myStartColor, streamState myStartState)
    {
        startValue = InitialValue;
        myColor = myStartColor;
        myState = myStartState;
    }

	public void SetStream(float InitialValue, streamColor myStartColor, streamState myStartState)
	{
		startValue = InitialValue;
		myColor = myStartColor;
		myState = myStartState;
	}

	public float currentValue{
		get { return finalValue; }
		set { finalValue = value; }
	}

    public streamColor _streamColor
    {
        get { return myColor; }
    }

    public float GetStreamValue()
    {
		finalValue = startValue;

        for (int modifier = 0; modifier < myModifiers.Count; modifier++)
        {
           myModifiers[modifier].Modify(this);
        }
		return finalValue;
    }

	public StreamModifier AddModifier{
		set { myModifiers.Add (value); }
	}

	public streamState GetState{
		get { return myState; }
        set { myState = value; }
	}

	public void ResetStream(){
		myModifiers.Clear ();
		myColor = streamColor.notSet;
		myState = streamState.unchanged;
		startValue = 0f;
		finalValue = 0f;
	}


	
}
