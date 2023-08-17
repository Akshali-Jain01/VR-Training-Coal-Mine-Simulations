using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCountDown : MonoBehaviour
{
    Coroutine routine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            if (!StaticData.isLiverSqueezed)
                return;
            if (routine != null)
            {
                StopCoroutine(routine);
                routine = null;
            }
            else
            {
                routine = StartCoroutine(StopFire());
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fire")
        {
            if (!StaticData.isLiverSqueezed)
                return;
            if (routine != null)
            {
                StopCoroutine(routine);
                routine = null;
            }
            

        }
    }

    IEnumerator StopFire()
    {
        yield return new WaitForSecondsRealtime(10);
        Manager.instance.DeactivateFire();
    }
}
