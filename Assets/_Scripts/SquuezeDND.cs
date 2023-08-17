using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquuezeDND : MonoBehaviour
{
   public void Squueze(bool _squeeze )
    {
        Debug.Log( "Squeeze++++++++ " + _squeeze );
        if ( _squeeze )
        {
            if ( StaticData.isPinRemoved && StaticData.isCylinderGrabbed )
            {
                CylinderManager.instance.lever.localEulerAngles = new Vector3( 45, 0, 0 );
                if ( StaticData.isHoosePicked )
                {
                    CylinderManager.instance.ActivateFoam( true );
                }
                else
                {
                    CylinderManager.instance.ActivateFoam( false );
                }
            }
        }
        else
        {
            CylinderManager.instance.ActivateFoam( false );
            CylinderManager.instance.lever.localEulerAngles = new Vector3( 0, 0, 0 );
        }
        StaticData.isLiverSqueezed = _squeeze;
    }
}
