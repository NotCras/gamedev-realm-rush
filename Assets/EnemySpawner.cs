using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(1,60)][SerializeField] private float secondsBetweenSpawn = 5f;
    [SerializeField] private EnemyMover enemyToSpawn;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioClip spawnEnemySFX;
    
    private int numEnemiesSoFar = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = numEnemiesSoFar.ToString();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        //instantiate an enemy
        //wait for a set amount of time between spawning another enemy
        while (true)
        {
            spawnEnemy();
            UpdateScoreUI();
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
        print("Spawning got out of while loop");
    }

    private void spawnEnemy()
    {
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity, gameObject.transform);
        GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
    }

    private void UpdateScoreUI()
    {
        numEnemiesSoFar++;
        scoreText.text = numEnemiesSoFar.ToString();
    }

}
