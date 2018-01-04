using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public static class StreamPool{
	private static List<ResourceStream> unUsedPool = new List<ResourceStream>();
	private static List<ResourceStream> usedPool = new List<ResourceStream>();

//	private static StreamPool myPool;

//	public static StreamPool getPool{
//		get { if (myPool == null) {
//				myPool = this;
//			}
//			return myPool; }
//	}

	public static void returnStream(ResourceStream myStream){
		myStream.ResetStream ();
		if (usedPool.Contains (myStream)) {
			usedPool.Remove (myStream);
		}
		unUsedPool.Add (myStream);
		//Debug.Log (unUsedPool.Count + usedPool.Count);
	}

	public static ResourceStream getStream(float value, streamState state, streamColor color){
		if (unUsedPool.Count > 0) {
			//Debug.Log (unUsedPool.Count + usedPool.Count);
			ResourceStream returnStream = unUsedPool [0];
			unUsedPool.Remove (returnStream);
			returnStream.SetStream (value, color, state);
			return returnStream;
		} else {
			ResourceStream returnStream = new ResourceStream (value, color, state);
			usedPool.Add (returnStream);
			Debug.Log (unUsedPool.Count + usedPool.Count);
			return returnStream;
		}
	}






}
