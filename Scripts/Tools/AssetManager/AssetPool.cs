using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


/// <summary>
/// An AssetPool pull UnityEngine Objects from Resouces and organize data into a list and dictionary 
/// </summary>
/// <typeparam name="T"></typeparam>
public class AssetPool <T> where T : UnityEngine.Object {

    protected List<T> myAssets = new List<T>();
    Dictionary<string, T> assetDictionary = new Dictionary<string, T>();
    public Dictionary<string,T> getAssetDictionary { get { return assetDictionary; } }

    /// <summary>
    /// Returns all gathered assets of the appropriate type as a list
    /// </summary>
    public List<T> getAssets { get { return myAssets; } }
   
    /// <summary>
    /// Asset pools take a directory structure to be built, starting with Resources as the root folder
    /// </summary>
    /// <param name="incPath"></param>
    public AssetPool(string incPath)
    {
        GetResources(incPath);   
    }

    protected void GetResources(string incPath)
    {
        try
        {
            var objs = Resources.LoadAll(incPath, typeof(T)).Cast<T>();

            foreach (var obj in objs)
            {
                myAssets.Add(obj);
                assetDictionary.Add(obj.name, obj);
            }
        }
        catch
        {
            Debug.LogError("Unable to build asset pool of type " + typeof(T) + " at path " + incPath);
        }

    }

    /// <summary>
    /// Gets asset by name within the Resouces folder
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public T getAssetByName(string Name)
    {
        try
        {
            return assetDictionary[Name];
        }
        catch
        {
            Debug.LogError("Unable to find object with name of " + Name + " in asset dictionary");
            return null;
        }
    }

   

}
