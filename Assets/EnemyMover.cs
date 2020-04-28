using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<block> path;  
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var point in path)
        {
            print(point.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
