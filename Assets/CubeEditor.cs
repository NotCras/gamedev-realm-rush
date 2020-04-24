using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode][SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [Range(1f,20f)][SerializeField] float gridSize = 10f;
    [SerializeField] private bool y_movement = false;

    private TextMesh textMesh;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        snapToGrid();
    }

    private void snapToGrid()
    {
        Vector3 snapPos;
        
        textMesh = GetComponentInChildren<TextMesh>();
        
        snapPos.x = (Mathf.RoundToInt(transform.position.x / gridSize)) * gridSize;
        snapPos.z = (Mathf.RoundToInt(transform.position.z / gridSize)) * gridSize;

        if (y_movement)
        {
            snapPos.y = (Mathf.RoundToInt(transform.position.y / gridSize)) * gridSize;
        }
        else
        {
            snapPos.y = 0f;
        }

        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;        

        transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);
    }
}
