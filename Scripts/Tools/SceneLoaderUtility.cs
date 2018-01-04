using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// use this class to smoothly load in classes that impliment the ILoadable interface
/// </summary>
public static class SceneLoaderUtility {

    static float progress = 0f;
    static bool isLoading = false;
    /// <summary>
    /// Smoothly loads each object that impliments the ILoadable interface. Yield on this in scene loading to smoothly load
    /// </summary>
    /// <param name="objectsToLoad"></param>
    /// <returns></returns>
    public static IEnumerator LoadGame(List<ILoadable> objectsToLoad) //take a list of ILoadables
    {
        isLoading = true;
        progress = 0f; //start out progress at 0
        for (int obj = 0; obj < objectsToLoad.Count; obj++) //load each thing
        {
            progress = obj; //passing into a float first so we can divide properly
            progress = progress / objectsToLoad.Count; //update progress
            yield return objectsToLoad[obj].Load();
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        progress = 1f;
        isLoading = false;
    }

    /// <summary>
    /// Get the current loading progress
    /// </summary>
    public static float GetLoadingProgress { get { return progress; } }
    public static bool GetIsLoading { get { return isLoading; } }


}
