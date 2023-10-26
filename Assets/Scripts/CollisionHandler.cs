using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    SceneManagerScript sceneManager;
    Collider collider;
    MeshCollider meshCollider;
    private void Awake()
    {
        sceneManager = FindAnyObjectByType<SceneManagerScript>();
        collider = GetComponent<Collider>();
        meshCollider = GetComponentInChildren<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Rock":
                Debug.Log("You hit rock");
                sceneManager.ReloadLevel();
                break;
            case "Finish":
                sceneManager.LoadNextLevel();
                Debug.Log("You finished level");
                break;
            
        }
    }

}
