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
    
    // Start is called before the first frame update
    void Start()
    {

    }

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
                SetBlockColor(w);
            }
        }
    }

    private void SetBlockColor(Waypoint w)
    {
        if (w == start)
        {
            w.SetTopColor(Color.red);
        }
        else if (w == end)
        {
            w.SetTopColor(Color.green);
        }
        else
        {
            w.SetTopColor(Color.white);
        }
    }

    void BreadthFirstSearch()
    {
        queue.Enqueue(start);

        while (queue.Count > 0 && isRunning)
        {
            currentSearchCenter = queue.Dequeue();
            currentSearchCenter.SetTopColor(Color.grey);
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
                neighbor.SetTopColor(Color.yellow); //todo: move this away later
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
            currentSearchCenter.SetTopColor(Color.green);
            isRunning = false;
        }
    }

    private void CreatePath()
    {
        path.Add(end);
        Waypoint previous = end.exploredFrom;
        while (previous != start)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        
        path.Add(start);
        path.Reverse();
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
