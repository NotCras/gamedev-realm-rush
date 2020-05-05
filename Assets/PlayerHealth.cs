using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 10;
    [SerializeField] private ParticleSystem buildingImpact;
    
    private void OnTriggerEnter(Collider other)
    {
        playerHealth--;

        //GetHurt();
    }

    private void GetHurt()
    {
        var vfx = Instantiate(buildingImpact, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
    }
}
