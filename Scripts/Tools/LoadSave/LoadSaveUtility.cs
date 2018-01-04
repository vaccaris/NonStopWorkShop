using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class LoadSaveUtility
{

    private static string playerSaveDataName = "/gameSave";
    private static GameSave mySave = null;

    public static GameSave getSave
    {
        get
        {
            if(mySave != null)
            {
                return mySave;
            }
            else
            {
                mySave = LoadGame();
                return mySave;
            }

        }
    }

    static GameSave LoadGame()
    {
        GameSave returnSave = new GameSave();
        try
        {
            if (File.Exists(Application.persistentDataPath + playerSaveDataName)) //if we already have a save
            {

                BinaryFormatter loadBF = new BinaryFormatter();
                FileStream loadFS = File.Open(Application.persistentDataPath + playerSaveDataName, FileMode.Open); //get the save
                try
                {
                    returnSave = (GameSave)loadBF.Deserialize(loadFS);  //deserialize it
                }
                catch
                {
                    returnSave = new GameSave();
                }//Debug.LogError("loading previous file");
                return returnSave; //and return it
            }
            else //if we don't currently have a save game file
            {
                //Debug.LogError("making new save file");
                mySave = returnSave;
                Save();
                return returnSave;
            }
        }
        catch
        {
            Debug.LogError("Unable to load the game");
            return returnSave;
        }
    }


    public static void Save()
    {
        try
        {
            BinaryFormatter saveBF = new BinaryFormatter();
            FileStream saveFile = File.Create(Application.persistentDataPath + playerSaveDataName);
            saveBF.Serialize(saveFile, mySave);
            saveFile.Close();
        }
        catch
        {
            Debug.LogError("Unable to save the game");
        }
    }

    public static void DeleteSave()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + playerSaveDataName))
            {
                //Debug.LogError("something is trying to delete a save");
                File.Delete(Application.persistentDataPath + playerSaveDataName);
            }
        }
        catch
        {
            Debug.LogError("unable to delete the save");
        }
    }




}
