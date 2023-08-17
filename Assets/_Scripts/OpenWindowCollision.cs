using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindowCollision : MonoBehaviour
{
    public Transform glasBox;
    void OnCollisionEnter( Collision _other )
    {
        glasBox.localEulerAngles = new Vector3(0,270,0 );
        Debug.Log("Glass should open" );
    }
}
