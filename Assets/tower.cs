using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private float attackRange = 7;

    [SerializeField] private ParticleSystem blaster;
    
    public Waypoint baseWaypoint;
    
    private Transform targetEnemy;
    
    void Start()
    {
        //blaster = GetComponent<ParticleSystem>();
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

    Transform CompareEnemyDistances(Transform enemyA, Transform enemyB)
    {
     
        var distA = Vector3.Distance(
            transform.position,
            enemyA.position
        );
        
        var distB = Vector3.Distance(
            transform.position, 
            enemyB.position
        );

        if (distB >= distA)
        {
            return enemyB;
        }

        return enemyA;
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
        }
        
    }
    
    private void ToggleBlaster(bool isActive)
    {
        var emissionModule = blaster.emission;
        emissionModule.enabled = isActive;
    }
}
