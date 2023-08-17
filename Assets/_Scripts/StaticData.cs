using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData
{
    public static bool isCylinderGrabbed = false;
    public static bool isPinRemoved=false;
    public static bool isLiverSqueezed=false;
    public static bool isHoosePicked = false;
    public static string language="";
    public static void ResetData()
    {
        isCylinderGrabbed = false;
        isLiverSqueezed = false;
        isPinRemoved = false;
        isHoosePicked = false;
       
    }
}
