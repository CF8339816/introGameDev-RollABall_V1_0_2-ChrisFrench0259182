using UnityEngine;

public class teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
          
            Transform destination = wormholeExits.Instance.GetRandomTargetPoint();

            if (destination != null)
            {
              
                other.transform.position = destination.position;
            }
        }
    }
}