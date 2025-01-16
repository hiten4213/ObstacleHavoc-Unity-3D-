using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class score : MonoBehaviour
{
    int currentscore = 0;

    private void OnCollisionEnter(Collision other) 
    {
      if(other.gameObject.tag == "Obstacle")
        { 
          currentscore++;
          UnityEngine.Debug.Log("You have hit an object "+currentscore+" time(s)");    
        }
    }
}
