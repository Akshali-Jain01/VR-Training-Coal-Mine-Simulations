using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderManager : MonoBehaviour
{
    public Transform lever;
    public GameObject foam;
    Coroutine fireCoroutine;
    public static CylinderManager instance;

    void Start()
    {
        instance = this;
    }
    public void PinRemoved()
    {
        StaticData.isPinRemoved = true;
    }

    public void CylinderPicked(bool _isCylinderPicked)
    {
        StaticData.isCylinderGrabbed = _isCylinderPicked;
        if(_isCylinderPicked)
        {
            SoundManager.instance.PlayMultipleAudio(5,9);
        }
    }

    public void SquuezeLiver(bool _squeeze)
    {
        Debug.Log("Squeeze++++++++ "+_squeeze );
        if ( _squeeze )
        {
            if ( StaticData.isPinRemoved && StaticData.isCylinderGrabbed )
            {
                lever.localEulerAngles = new Vector3( 45, 0, 0 );
                if(StaticData.isHoosePicked)
                {
                    ActivateFoam( true );
                }
                else
                {
                    ActivateFoam( false);
                }
            }
        }
        else
        {
            ActivateFoam( false );
            lever.localEulerAngles = new Vector3( 0,0,0);
        }
        StaticData.isLiverSqueezed = _squeeze;
    }
    public void GrabHoose( bool _hosePicked )
    {
        StaticData.isHoosePicked = _hosePicked;

    }

    public void ActivateFoam(bool _activateFoam)
    {
        foam.SetActive( _activateFoam );
        if(_activateFoam)
        {
            if ( fireCoroutine != null )
            {
                StopCoroutine( FireCountDown( ) );
            }
            fireCoroutine = StartCoroutine( FireCountDown());
        }
        else
        {
            if(fireCoroutine!=null)
            {
                StopCoroutine( FireCountDown( ) );
            }
        }
    }
    IEnumerator FireCountDown()
    {
        yield return new WaitForSecondsRealtime( 7 );
        Manager.instance.DeactivateFire( );
    }

}
