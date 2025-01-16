using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    Rigidbody cube;
    MeshRenderer rendererr;
    [SerializeField] float timetowait = 3f;
    void Start()
    {
        cube = GetComponent<Rigidbody>();
        rendererr = GetComponent<MeshRenderer>();
        rendererr.material.color = Color.yellow;
    }

    
    void Update()
    {
        objectdrop();
    }

  void objectdrop()
  {
    if(Time.time > timetowait)
    {
        cube.useGravity = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
    else
    {
       cube.useGravity = false;
       rendererr.enabled = false;
    }
  }
  
}
