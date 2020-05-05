using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] tower towerPrefab;
    [FormerlySerializedAs("numberOfTowers")] [SerializeField] private int towerNumLimit = 3;
    
    public Queue<tower> towerQueue = new Queue<tower>();

    public void placeTower(Waypoint w)
    {
        var numTowers = towerQueue.Count;
        
        if (numTowers < towerNumLimit)
        {
            InstantiateNewTower(w);
        }
        else
        {
            MoveAnExistingTower(w);
        }
        
    }

    private void InstantiateNewTower(Waypoint w)
    {
        var newTower = Instantiate(towerPrefab, w.transform.position, Quaternion.identity, gameObject.transform);
        w.isPlaceable = false;
        
        newTower.baseWaypoint = w;
        
        //put new tower on the queue
        towerQueue.Enqueue(newTower);
    }

    private void MoveAnExistingTower(Waypoint w)
    {
        tower towerToMove = towerQueue.Dequeue();

        towerToMove.baseWaypoint.isPlaceable = true;
        towerToMove.baseWaypoint = w;

        towerToMove.transform.position = w.transform.position;
        towerQueue.Enqueue(towerToMove);
    }
}
