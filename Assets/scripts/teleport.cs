using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;
    
   void OnTriggerEnter(Collider other)
    {
     
        //if (other.CompareTag("Player"))
        //{

            Player.transform.position = teleportTarget.transform.position;

            //if (destination != null)
            //{
              
            //    other.transform.position = destination.position;
            //}
        //}
    }
}