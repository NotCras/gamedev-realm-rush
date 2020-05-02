using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Vector2Int gridPos;
    const int gridSize = 10;
    
    // public is ok here because it is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public int getGridSize()
    {
        return gridSize;
    }
    
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        print("Mouse is over GameObject: " + gameObject.name);
    }

    public Vector2Int getGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize), 
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
