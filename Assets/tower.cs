using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private float attackRange = 7;

    [SerializeField] private ParticleSystem blaster;

    private Transform targetEnemy;
    
    void Start()
    {
        //blaster = FindObjectOfType<ParticleSystem>();
        ToggleBlaster(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            ToggleBlaster(false);
            print(gameObject.name + " turning off blaster. No enemies!");
        }
        

    }

    void SetTargetEnemy()
    {
        var existingEnemies = FindObjectsOfType<Enemy>();
        
        if (existingEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = existingEnemies[0].transform;

        foreach (var testEnemy in existingEnemies)
        {
            closestEnemy = CompareEnemyDistances(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    Transform CompareEnemyDistances(Transform priorChamp, Transform challenger)
    {
     
        var champDistance = Vector3.Distance(
            transform.position,
            priorChamp.position
        );
        
        var challengerDistance = Vector3.Distance(
            transform.position,
            challenger.position
        );

        if (challengerDistance >= champDistance)
        {
            return challenger;
        }

        return priorChamp;
    }
    
    
    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(
            targetEnemy.transform.position,
            gameObject.transform.position
        );
        
        if (distanceToEnemy <= attackRange)
        {
            ToggleBlaster(true);
        }
        else
        {
            ToggleBlaster(false);
            print(gameObject.name + " turning off blaster.");
        }
        
    }
    
    private void ToggleBlaster(bool isActive)
    {
        var emissionModule = blaster.emission;
        emissionModule.enabled = isActive;

    }
}
