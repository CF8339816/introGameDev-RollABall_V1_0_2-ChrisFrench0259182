using UnityEngine;
using System.Collections.Generic;

public class wormholeExits : MonoBehaviour
{
    public static wormholeExits Instance { get; private set; }

   
    public List<Transform> randomTeleportPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

  
    public Transform GetRandomTargetPoint()
    {
        if (randomTeleportPoints == null || randomTeleportPoints.Count == 0)
        {
            Debug.LogError("No random teleport points assigned to TeleportManager!");
            return null;
        }

        int randomIndex = Random.Range(0, randomTeleportPoints.Count);
        return randomTeleportPoints[randomIndex];
    }
}