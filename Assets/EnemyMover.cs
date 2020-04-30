using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float dwellTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPathFound();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> pathway)
    {
        print("Starting movement.");

        foreach (var w in pathway)
        {
            transform.position = w.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }

        print("Ending movement. ");
    }
}