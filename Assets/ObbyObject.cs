using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObbyObject : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector= Vector3.zero;
    [SerializeField] [Range(0,1)] float movementFactor = 0f;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        if (period < Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI / 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startPosition + offset;
    }
}
