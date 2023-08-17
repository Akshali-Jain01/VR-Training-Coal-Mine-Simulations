using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectReturn : MonoBehaviour
{
    //Vector3 startRotation;
    private Vector3 spawnPos = Vector3.zero;
    private Quaternion spawnRot = Quaternion.identity;
  
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = gameObject.transform.position;
        spawnRot = gameObject.transform.rotation;



    }
public void hold()
    {
        gameObject.transform.position = spawnPos;
        gameObject.transform.rotation = spawnRot;
    }
  
}
