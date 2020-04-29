using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Vector2Int gridPos;
    const int gridSize = 10;

    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int getGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, 
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);
    }


}
