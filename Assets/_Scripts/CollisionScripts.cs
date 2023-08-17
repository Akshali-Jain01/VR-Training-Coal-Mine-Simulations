using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScripts : MonoBehaviour
{

   void OnCollisionEnter(Collision _other)
    {
        Manager.instance.PlayAlarmSound( );
    }
}
