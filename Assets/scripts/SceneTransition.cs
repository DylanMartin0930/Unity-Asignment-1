using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;

 
    public void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger");
        if (other.CompareTag("Player"))
        {
            print("Player Detected");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
