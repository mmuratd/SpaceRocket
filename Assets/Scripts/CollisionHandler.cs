using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    Collider collider;
    MeshCollider meshCollider;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        meshCollider = GetComponentInChildren<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
