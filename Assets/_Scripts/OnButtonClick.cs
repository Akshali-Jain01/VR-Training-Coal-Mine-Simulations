using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnButtonClick : MonoBehaviour
{
    public UnityEvent onClickEvent;

    public void Click()
    {
        onClickEvent.Invoke( );
    }
}
