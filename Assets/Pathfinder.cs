using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();
    
    [SerializeField] private Waypoint start;
    [SerializeField] private Waypoint end;
    [SerializeField] private GameObject pathIndicator;
    
    private bool isRunning = true;
    private bool alreadyRun = false;
    private Waypoint currentSearchCenter;

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (var w in waypoints)
        {
            var gridPos = w.getGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Duplicate block at " + gridPos);
            }
            else
            {
                grid.Add(gridPos, w);
            }
        }
    }
    

    void BreadthFirstSearch()
    {
        queue.Enqueue(start);

        while (queue.Count > 0 && isRunning)
        {
            currentSearchCenter = queue.Dequeue();
            currentSearchCenter.isExplored = true; 

            HaltIfEndFound();
            ExploreNeighbors();
        }
    }
    
    void ExploreNeighbors()
    {
        foreach (Vector2Int vec in directions)
        {
            QueueNewNeighbors(vec);
        }
    }

    private void QueueNewNeighbors(Vector2Int vec)
    {
        Vector2Int pointToExplore = new Vector2Int(
            vec.x + currentSearchCenter.getGridPos().x,
            vec.y + currentSearchCenter.getGridPos().y
        );

        if (grid.ContainsKey(pointToExplore))
        {
            Waypoint neighbor = grid[pointToExplore];
            
            if (!neighbor.isExplored)
            {
                neighbor.exploredFrom = currentSearchCenter;
                queue.Enqueue(neighbor);
            }
        }
    }

    private void HaltIfEndFound()
    {
        if (!isRunning)
        {
            return;
        }

        if (currentSearchCenter == end)
        {
            isRunning = false;
        }
    }

    private void CreatePath()
    {
        AddToPath(end);
        Waypoint previous = end.exploredFrom;
        
        while (previous != start)
        {
            AddToPath(previous);
            previous = previous.exploredFrom;
        }

        AddToPath(start);
        path.Reverse();
    }

    private void AddToPath(Waypoint w)
    {
        path.Add(w);
        Instantiate(pathIndicator, w.transform.position, Quaternion.identity, this.transform);
        w.isPlaceable = false;
    }

    public List<Waypoint> GetPathFound()
    {
        if (!alreadyRun)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
            alreadyRun = true;
            return path;
        }
        else
        {
            return path;
        }

    }
}
