using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 5;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        //emitters = GetComponents<ParticleSystem>();
    }

    void AddNonTriggerBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        boxCollider.size = new Vector3(5f, 5f, 5f);
        boxCollider.center = new Vector3(0f, 4f, 0f);
        
    }
    
    private void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
        hitParticlePrefab.Play();
        
        if (enemyHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play(); //todo: destroy the particlesystem after it is instantiated, keep things clean
        
        Destroy(this.gameObject);
        /*foreach (var p in emitters)
        {
            Destroy(p);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
