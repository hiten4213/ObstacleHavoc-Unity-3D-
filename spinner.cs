using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
    Transform cube;
    [SerializeField] float spinamt = 5f;
    
    void Start()
    {
        cube = GetComponent<Transform>();
    }

    
    void Update()
    {
        spin();
    }

    void spin()
    {
        cube.Rotate(0,spinamt*Time.deltaTime,0);
    }
}
