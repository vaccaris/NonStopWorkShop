using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HarvestingNode : GridGameObject {

    public float initialValue;
    public streamColor initialColor;
    public streamState initialState;

    public List<IOStreamDir> SetOutputs;

    public override void Create()
    {
        this.StreamOutputs = SetOutputs;

        int color = Random.Range(0, 3);
        switch (color)
        {
            case 0:
                initialColor = streamColor.blue;
                break;
            case 1:
                initialColor = streamColor.green;
                break;
            case 2:
                initialColor = streamColor.red;
                break;
            default:
                initialColor = streamColor.notSet;
                break;
        }
    }

    

    public override void Init()
    {
        //base.Init();
        //  this.SetAllStreamAsOutput();
      
    }

    public override void RunOnAwake()
    {
        base.RunOnAwake();
		ResourceStream newStream = StreamPool.getStream (initialValue, initialState, initialColor);
        this.animColor = newStream._streamColor;
        this.Stream = newStream;
        this.PassStream();

    }

   






}
