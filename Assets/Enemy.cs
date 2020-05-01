using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 5;
    private ParticleSystem[] emitters;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        emitters = FindObjectsOfType<ParticleSystem>();
    }

    void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    
    private void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        Destroy(this.gameObject);
        foreach (var p in emitters)
        {
            Destroy(p);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
