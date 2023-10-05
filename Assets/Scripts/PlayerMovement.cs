using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float powerOfMotor = 100f;
    [SerializeField] float rotationSpeed = 1f;

    Rigidbody rb;
    Vector2 input;
    Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
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
        
        rb.AddRelativeForce(Vector3.up * powerOfMotor * input.y * Time.deltaTime);
    }

    void ProcessRotation()
    {
        transform.Rotate(0, 0, -input.x * rotationSpeed * Time.deltaTime);
        
    }
}
