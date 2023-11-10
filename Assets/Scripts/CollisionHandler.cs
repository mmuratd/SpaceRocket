using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] AudioClip crashAudioClip;
    [SerializeField] AudioClip finishAudioClip;
    

    [Header("Particles")]
    [SerializeField] ParticleSystem crashParticleSystem;
    [SerializeField] ParticleSystem finishParticleSystem;
    SceneManagerScript sceneManager;

    //Collider collider;
    //MeshCollider meshCollider;
    Transform finishObjectTransform;
    AudioSource audioSource;

    bool isTransitioning = false;

    public float reloadTime = 1f;
    private void Awake()
    {
        sceneManager = FindAnyObjectByType<SceneManagerScript>();
        //collider = GetComponent<Collider>();
        //meshCollider = GetComponentInChildren<MeshCollider>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) return;

        switch (collision.gameObject.tag) 
        {
            case "Rock":
                Debug.Log("You hit rock");
                StartCrashSequence();
                break;
            case "Finish":
                finishObjectTransform = collision.transform;
                StartFinishSequence();
                Debug.Log("You finished level");
                break;
            
        }
    }

    private void StartCrashSequence()
    {

        BeforeStartSequence();

        crashParticleSystem.Play();
        audioSource.PlayOneShot(crashAudioClip);
        Invoke("ReloadLevel", reloadTime);
    }

    private void StartFinishSequence()
    {
        BeforeStartSequence();

        Instantiate(finishParticleSystem, finishObjectTransform);
        audioSource.PlayOneShot(finishAudioClip);
        Invoke("LoadNextLevel", reloadTime);
    }
    private void BeforeStartSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<PlayerMovement>().enabled = false;
    }
    private void ReloadLevel()
    {
        sceneManager.ReloadLevel();
    }
    private void LoadNextLevel()
    {
        sceneManager.LoadNextLevel();
    }

}
