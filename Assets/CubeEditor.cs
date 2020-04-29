using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode][SelectionBase][RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    const bool y_movement = false;
    private TextMesh textMesh;
    
    private Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateGridLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.getGridSize();
        textMesh = GetComponentInChildren<TextMesh>();
        transform.position = new Vector3(
            waypoint.getGridPos().x,
            0f,
            waypoint.getGridPos().y);
    }

    private void UpdateGridLabel()
    {
        int gridSize = waypoint.getGridSize();
        Vector3 gridPos = new Vector3(
            waypoint.getGridPos().x, 
            0f, 
            waypoint.getGridPos().y);
        
        String labelText = gridPos.x / gridSize + "," + gridPos.z / gridSize;

        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
