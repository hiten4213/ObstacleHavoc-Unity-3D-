using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class end : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ReloadScene();
            
        }
    }
    void ReloadScene()
  {
     Debug.Log("You Win");
     SceneManager.LoadScene(0);
  }
}
