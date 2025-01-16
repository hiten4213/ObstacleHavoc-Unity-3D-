using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gethit : MonoBehaviour
{
    MeshRenderer mesh;
    [SerializeField] Material ouch;

 void Start()
 {
    mesh = GetComponent<MeshRenderer>();
 }
    private void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.tag == "Player")
        {
            mesh.material.color = Color.red;
            gameObject.tag = "Hit";
        }
    }
}
