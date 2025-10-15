using UnityEngine;

public class Rotator : MonoBehaviour
{
           void Update()
    {
            transform.Rotate(new Vector3(15, 30, 75) * Time.deltaTime); // Rotates object X,Y,,Z axes specifiedway, adjusted for f-r
    }

}