using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 10;
    [SerializeField] private ParticleSystem buildingImpact;
    [SerializeField] private Text healthText;
    
    
    void Start()
    {
        healthText.text = playerHealth.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {

        playerHealth--;
        healthText.text = playerHealth.ToString();
        
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
