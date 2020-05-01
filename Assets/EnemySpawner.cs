using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1,60)][SerializeField] private float secondsBetweenSpawn = 5f;
    [SerializeField] private EnemyMover enemyToSpawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        //instantiate an enemy
        //wait for a set amount of time between spawning another enemy
        while (true)
        {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
        print("Spawning got out of while loop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
