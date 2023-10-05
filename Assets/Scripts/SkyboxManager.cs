using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{

    [SerializeField] float speedOfSky = 1f;


    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speedOfSky);
    }
}

