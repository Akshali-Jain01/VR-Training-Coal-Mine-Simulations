using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventActions : MonoBehaviour
{
    public UnityEvent eventTrigger;

    public void CallMethods()
    {
        eventTrigger.Invoke( );
    }
}
