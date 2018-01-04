using UnityEngine;
using System.Collections;

public static class IOCalculator {

    /*
    public static bool CanInput(IOStreamDir myOutput, IOStreamDir targetInput, IOStreamDir myOutput2 = IOStreamDir.Null, IOStreamDir targetInput2 = IOStreamDir.Null)
    {
        bool canInput = false;
        bool canInputOne = false;
        if ((myOutput != IOStreamDir.Null && targetInput != IOStreamDir.Null)&&(myOutput2 == IOStreamDir.Null && targetInput2 == IOStreamDir.Null))
        {
            if (myOutput == IOStreamDir.Top && targetInput == IOStreamDir.Bottom)
            {
                canInputOne = true;
            }
            else if (myOutput == IOStreamDir.Right && targetInput == IOStreamDir.Left)
            {
                canInputOne = true;
            }
            else if (myOutput == IOStreamDir.Bottom && targetInput == IOStreamDir.Top)
            {
                canInputOne = true;
            }
            else if (myOutput == IOStreamDir.Left && targetInput == IOStreamDir.Right)
            {
                canInputOne = true;
            }
        }else if ((myOutput != IOStreamDir.Null && targetInput != IOStreamDir.Null) && (myOutput2 != IOStreamDir.Null && targetInput2 != IOStreamDir.Null))
        {
            //this is where I will put stuff for multi pipe drifting, just add it in later
        }
            return canInput;
    }
    */

    public static bool CanInput(IOType myOutput, IOType targetInput, IOType myOutput2 = IOType.Null, IOType targetInput2 = IOType.Null)
    {
        bool canInput = false;
        bool canInputOne = false;
        if ((myOutput != IOType.Null && targetInput != IOType.Null) && (myOutput2 == IOType.Null && targetInput2 == IOType.Null))
        {
            if (myOutput == IOType.Output && targetInput == IOType.Input)
            {
                canInputOne = true;
            }
          //  else if (myOutput == IOType.Right && targetInput == IOType.Left)
            //{
            //    canInputOne = true;
            //}
            //else if (myOutput == IOType.Bottom && targetInput == IOType.Top)
            //{
            //    canInputOne = true;
            //}
            //else if (myOutput == IOType.Left && targetInput == IOType.Right)
            //{
            //    canInputOne = true;
            //}
        }
        else if ((myOutput != IOType.Null && targetInput != IOType.Null) && (myOutput2 != IOType.Null && targetInput2 != IOType.Null))
        {
            //this is where I will put stuff for multi pipe drifting, just add it in later
        }
        return canInput;
    }




}
