using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Manager : MonoBehaviour
{
    public GameObject[] platforms; // Array of platforms
    public float platformFallSpeed = 2.0f; // Speed at which platforms fall
    public float platformFallDelay = 2.0f; // Delay before platforms start falling
    public float disappearDelay = 10.0f; // Time Delay after payer jumps on platform

    private void Start()
    {
        // Start the platform falling coroutine
        //StartCoroutine(SpawnPlatforms());

        Debug.Log(platforms.Length);
    }

   

}
