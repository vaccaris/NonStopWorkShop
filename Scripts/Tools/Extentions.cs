using System.Collections.Generic;
using UnityEngine;

public static class Extentions{

    
    /// <summary>
    /// this is a dictionary extention that lets us get from a dictionary, but adds a default value for a key if it doesn't exist in the dictionary 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"> default value to place into dictionary if no value is found</param>
    /// <returns></returns>
    public static U GetOrDefault<T, U>(this Dictionary<T, U> dic, T key, U defaultValue)
    {
        if (dic.ContainsKey(key))
        {
            return dic[key];
        }
        else
        {
            dic.Add(key, defaultValue);
            return dic[key];
        }
    }

    /// <summary>
    /// Checks if a dictionary contains a key to modify the value, if the dictionary does not contain that key, it adds it with the new value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <param name="newValue"></param>
    public static void SetOrAdd<T,U>(this Dictionary<T,U> dic, T key, U newValue)
    {
        if (dic.ContainsKey(key))
        {
            dic[key] = newValue;
        }
        else
        {
            dic.Add(key, newValue);
        }
    }

    /// <summary>
    /// uses random.range to return a random value from a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T GetRandomValue<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    /// <summary>
    /// Resets all of a transforms local values
    /// </summary>
    /// <param name="trans"></param>
    public static void ResetLocal(this Transform trans)
    {
        trans.localPosition = Vector3.zero;
        trans.localScale = Vector3.one;
        trans.localRotation = Quaternion.identity;
    }

    /// <summary>
    /// Takes an isntance of a monobehavior class as an argument to see if that class exists in the scene.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="asking"></param>
    /// <param name="curInstance">This should be a private static instance of the class</param>
    /// <returns></returns>
    public static T GetOrDebug<T>(this T asking, T curInstance) where T : MonoBehaviour
    {  
        if( curInstance != null)
        {
            return curInstance;
        }
        else
        {
            if (Object.FindObjectOfType<T>() != null)
            {
                curInstance = Object.FindObjectOfType<T>();
                return curInstance;
            }
            else
            {
                Debug.LogError("Something in the scene is looking for " + typeof(T).ToString() + " in the scene but it cannot be found");
                return null;
            }
        }
        
    }

    public static float Divide(this Vector3 vec, Vector3 vec1, Vector3 vec2)
    {
        int nonZeroValues = 0;

        float x = 0;
        if (vec1.x != 0 || vec2.x != 0)
        {
            x = vec1.x / vec2.x;
            nonZeroValues++;
        }

        float y = 0;
        if (vec1.y != 0 || vec2.y != 0)
        {
            y = vec1.y / vec2.y;
            nonZeroValues++;
        }

        float z = 0;
        if (vec1.z != 0 || vec2.z != 0)
        {
            z = vec1.z / vec2.z;
            nonZeroValues++;
        }

        // float y = vec1.y / vec2.y;
        // float z = vec1.z / vec2.z;
        //Debug.Log(vec1 + " " + vec2);
        float returnFloat = (x + y + z) / nonZeroValues;
        //Debug.Log(x + " " + y + " " + z);
        //Debug.Log(returnFloat);

        return returnFloat;
    }

}
