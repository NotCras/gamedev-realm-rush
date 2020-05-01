﻿using System;
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
            waypoint.getGridPos().x * gridSize,
            0f,
            waypoint.getGridPos().y * gridSize);
    }

    private void UpdateGridLabel()
    {
        Vector2Int gridPos = waypoint.getGridPos();
        
        String labelText = gridPos.x + "," + gridPos.y;

        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
