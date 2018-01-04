using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum IOStreamDir{
	Null,
	Top,
	Bottom,
	Right,
	Left,
	TopRight,
	TopLeft,
	BottomRight,
	BottomLeft,
	LeftTop,
	LeftBottom,
	RightTop,
	RightBottom
}

public enum IOType
{
    Null,
    Input,
    Output,
    InputOutput

}

public enum runningState{
	notRunning,
	running,
	incorrectInput,
	incorrectOutput
}

public enum Facing
{
    up,
    right,
    down,
    left
}

public class GridGameObject : MonoBehaviour {

    public runningState animState;

    public streamColor animColor;

    public GameObject myMesh;

    public float buildCost;

    public bool isEditable;

    private List<IOStreamDir> myInputs = new List<IOStreamDir>();

    private List<IOStreamDir> myOutputs = new List<IOStreamDir>();

    private List<GridGameObject> myNeighbors = new List<GridGameObject>();

    private List<IOStreamDir> MyNeighborOutPut = new List<IOStreamDir> ();

    public ResourceStream myStream;

    private GridPiece myParent = null;

	public runningState myState = runningState.notRunning;

	private streamState myProcessing = streamState.unchanged;

    Facing myFacing = Facing.up;

    public AnimationSetting myAnimator;

    public streamState StreamprocessingType{
		get { return myProcessing; }
		set { myProcessing = value; }
	}

	public runningState ChangeState{
		set { myState = value; }
		get { return myState; }
	}

    public GridPiece SetMyPiece
    {
        set { myParent = value; }
        get { return myParent; }
    }

    public void SetAllStreamsAsInput()
    {
        myInputs.Clear();
        myInputs.Add(IOStreamDir.Top);
        myInputs.Add(IOStreamDir.Right);
        myInputs.Add(IOStreamDir.Bottom);
        myInputs.Add(IOStreamDir.Left);

       
    }

    public void SetAllStreamAsOutput()
    {
        myOutputs.Clear();
        myOutputs.Add(IOStreamDir.Top);
        myOutputs.Add(IOStreamDir.Right);
        myOutputs.Add(IOStreamDir.Bottom);
        myOutputs.Add(IOStreamDir.Left);
      
    }

    public List<IOStreamDir> StreamOutputs
    {
        get { return myOutputs; }
        set { myOutputs = value; }
    }


    public List<IOStreamDir> StreamInputs
    {
        get { return myInputs; }
        set { myInputs = value; }
    }

    public ResourceStream Stream
    {
        get { return myStream; }
        set { myStream = value; }
    }


    public void ReceiveStream(ResourceStream ReceivingStream, IOStreamDir ReceivingDir)
    {
        RemoveFromStream(ReceivingDir);
        Stream = ReceivingStream;
        animColor = ReceivingStream._streamColor;
        this.ManageStream();
    }

    public void StopRunning()
    {
        animState = runningState.notRunning;
        myState = runningState.notRunning;
        //animColor = streamColor.notSet;
        if (myStream != null)
        {
            StreamPool.returnStream(myStream);
            myStream = null;
        }
        ManageAnimator();
    }

    public void RemoveFromStream(IOStreamDir ReceivingStream)
    {
        

    }

    

    public virtual void Create()
    {

    }


    public virtual void Init()
    {
        //This will be called to initilize any child objects that have initializations 
    }

    public virtual void RunOnAwake()
    {
        //this will be overridden by child objects that "start" such as the harvesting nodes
    }


    public virtual void ManageStream()
    {
        //this is currently empty on purpose, there should be nothing running in this manage stream, manage stream should be overriden by each
        //child class to manage the stream in the way that they each deem appropriate 
    }

    public void PassStream()
    {
     //   Debug.Log(this.transform.name + "Is passing OBJ");

		myNeighbors.Clear ();
		MyNeighborOutPut.Clear ();
		for (int output = 0; output < myOutputs.Count; output++)
        {
           // Debug.Log(myOutputs[output]);
            if(myParent.GetNeighbor(myOutputs[output]) != null) {
                if (myInputs.Contains(myOutputs[output])){
                    myInputs.Remove(myOutputs[output]);
                }
				myNeighbors.Add (myParent.GetNeighbor (myOutputs [output]));
				MyNeighborOutPut.Add (myOutputs [output]);
              // .ReceiveStream(myStream, myOutputs[output]);
               
               // return;
               
            }
        }
		//Debug.Log (myStream.currentValue);
		 //myStream.currentValue = myStream.currentValue / myNeighbors.Count + 1;
		//Debug.Log (myStream.currentValue + " : " + myNeighbors.Count);
		if (myNeighbors.Count > 0) {
			myState = runningState.running;
			for (int neighbor = 0; neighbor < myNeighbors.Count; neighbor++) {
				myNeighbors [neighbor].ReceiveStream (myStream, MyNeighborOutPut [neighbor]);
			}
		} else {
			StreamPool.returnStream (this.Stream);
			myState = runningState.incorrectOutput;
         
		}
        ManageAnimator();
    }

    public void Rotate(int dir) //+1 to rotate right, -1 to rotate left
    {
       
        if(dir > 0) //if we're rotating right
        {
            myInputs = rotateRight(myInputs);
            myOutputs = rotateRight(myOutputs);
         //   Debug.Log(myInputs.Count);
            myMesh.transform.Rotate(Vector3.up, 90f);
        }else if(dir < 0) //if we're rotating left
        {
            myInputs = rotateLeft(myInputs);
            myOutputs = rotateLeft(myOutputs);
            myMesh.transform.Rotate(Vector3.up, -90f);

        }
        else //if somebody fucked up the input
        {
            return;
        }
        StopNeighbors();
        myNeighbors.Clear();
        MyNeighborOutPut.Clear();
       // this.Init();
        myState = runningState.notRunning;
        ManageAnimator();



    }

    public void ManageAnimator()
    {
        animState = myState;
        
        //if (myAnimator != null)
        //{
        //   myAnimator.setAnimState(this);
        //}
    }
    List<IOStreamDir> rotateRight(List<IOStreamDir> myStream)
    {
        List<IOStreamDir> returnStream = myStream;
      //  Debug.Log(myStream.Count);
        for (int streami = 0; streami < returnStream.Count; streami++)
        {
//            Debug.Log("fuck");

          //  Debug.Log(returnStream[streami]);   
            switch (returnStream[streami])
            {
                case IOStreamDir.Top:
                    returnStream[streami] = IOStreamDir.Right;
                    break;
                case IOStreamDir.Right:
                    returnStream[streami] = IOStreamDir.Bottom;
                    break;
                case IOStreamDir.Bottom:
                    returnStream[streami] = IOStreamDir.Left;
                    break;
                case IOStreamDir.Left:
                    returnStream[streami] = IOStreamDir.Top;
                    break;
                default:
                    Debug.LogError("The rotation calculator is not ready to handle the stream dir of: " + returnStream[streami]);
                    break;
            }
         //   Debug.Log(returnStream[streami]);
        }
        return returnStream;
    }

    List<IOStreamDir> rotateLeft(List<IOStreamDir> myStream)
    {
        List<IOStreamDir> returnStream = myStream;
        for (int stream = 0; stream < returnStream.Count; stream++)
        {
            switch (returnStream[stream])
            {
                case IOStreamDir.Top:
                    returnStream[stream] = IOStreamDir.Left;
                    break;
                case IOStreamDir.Left:
                    returnStream[stream] = IOStreamDir.Bottom;
                    break;
                case IOStreamDir.Bottom:
                    returnStream[stream] = IOStreamDir.Right;
                    break;
                case IOStreamDir.Right:
                    returnStream[stream] = IOStreamDir.Top;
                    break;
                default:
                    Debug.LogError("The rotation calculator is not ready to handle the stream dir of: " + returnStream[stream]);
                    break;
            }
        }
        return returnStream;
    }

    public void StopNeighbors()
    {//call this when we destroy the object to deactivate neighbors
        for (int neighbor = 0; neighbor < myNeighbors.Count; neighbor++)
        {
            myNeighbors[neighbor].StopRunning();
        }
    }


}
