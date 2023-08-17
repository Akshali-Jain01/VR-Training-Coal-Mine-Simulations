using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DrawRay : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerClick;
    public SteamVR_Input_Sources inputSource;
    public LineRenderer lr;
    void Start()
    {

    }

    void Update()
    {
        //Debug.DrawLine( transform.position, transform.TransformDirection( Vector3.forward ), Color.red, Mathf.Infinity );
        lr.SetPosition( 0, transform.position );
        lr.SetPosition( 1, transform.position+transform.forward*20);

    }

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener( Press, inputSource );
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener( Press, inputSource );
    }

    private void Press( SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource )
    {
        
        RaycastHit hit;
        Debug.Log("Trigger Pressed" );
        if ( Physics.Raycast( transform.position, transform.TransformDirection( Vector3.forward ), out hit, Mathf.Infinity ) )
        {
            if(hit.collider.gameObject.layer==5)//Ui Layer
            {
                hit.collider.GetComponent<OnButtonClick>( ).Click( );
                Debug.Log( "Clicked");
            }
            
        }
    }
}