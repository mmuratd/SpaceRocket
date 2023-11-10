using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float powerOfMotor = 100f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] AudioClip mainEngineAudioClip;

    [Header("Particles")]
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftEngineParticle;
    [SerializeField] ParticleSystem rightEngineParticle;

    AudioSource audioSource;
    Rigidbody rb;
    Vector2 input;
    //Transform transform;
    

    private void Awake()
    {
        //transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>(); 
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
        
    }
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
    void OnFire(InputValue value)
    {
        
    }
    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        
    }
    void ProcessThrust()
    {  
        if (input.y  > 0)
        {
            rb.AddRelativeForce(Vector3.up * powerOfMotor * input.y * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                mainEngineParticle.Play();
                audioSource.PlayOneShot(mainEngineAudioClip);
                
            }
        } else
        {
            mainEngineParticle.Stop();
            audioSource.Stop();
        }
        
        
    }

    void ProcessRotation()
    {

        if (input.x < 0)
        {
            rightEngineParticle.Play();
        }
        else if (input.x > 0) 
        {
            leftEngineParticle.Play();
        }
        else 
        {
            rightEngineParticle.Stop();
            leftEngineParticle.Stop();
        }
        transform.Rotate(0, 0, -input.x * rotationSpeed * Time.deltaTime);
        
    }
}
