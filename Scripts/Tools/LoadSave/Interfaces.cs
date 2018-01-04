using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Impliment this interface to build a list of loadable objects, which we can use to load one at a time with the sceneloadingutility 
/// </summary>
public interface ILoadable
{
    IEnumerator Load();
}


