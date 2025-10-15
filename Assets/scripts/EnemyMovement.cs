using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    public Transform player; // ref player transform.

    
    private NavMeshAgent navMeshAgent; // Ref NavMeshAgent for pathfinding.

    // Start is called before the first frame update.
    void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get and store NavMeshAgent attached to object.
    }

    
    void Update() // Update called once/frame.
    {
       
        if (player != null)  // checks for ref to player
        {
           
            navMeshAgent.SetDestination(player.position);  // Set enemy destination to player location.
        }
    }
}