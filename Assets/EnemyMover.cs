using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;
    [SerializeField] private float dwellTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }
    
    
    IEnumerator FollowPath()
    {
        print("Starting patrol.");
        
        foreach (var w in path)
        {
            transform.position = w.transform.position;
            print("Visiting " + w.name);
            yield return new WaitForSeconds(dwellTime);
        }

        print("Ending patrol. ");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
