using UnityEngine;

public class teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check for the player tag
        if (other.CompareTag("Player"))
        {
            // Request a random target location from the scene's manager
            Transform destination = wormholeExits.Instance.GetRandomTargetPoint();

            if (destination != null)
            {
                // Teleport the player's transform to the random location
                other.transform.position = destination.position;
            }
        }
    }
}