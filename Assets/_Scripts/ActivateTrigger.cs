using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    private BoxCollider collider;

    public void ActivateTriggers()
    {
        collider = GetComponent<BoxCollider>();
        StartCoroutine(UnTrigger());
    }
    private IEnumerator UnTrigger()
    {
        yield return new WaitForSecondsRealtime(3f);
        collider.isTrigger = false;
    }
}
