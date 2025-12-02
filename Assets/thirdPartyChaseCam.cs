using UnityEngine;

public class thirdPartyChaseCam : MonoBehaviour
{

    public Transform followTarget;
    public Transform LookTarget;
    public float followSpeed = 10f;
   // public Vector3 offset = new Vector3(0f, 3f, -10f);






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

   void Update()
    {
        
    }

    private void LateUpdate()
    {

        Vector3 targetPosition = followTarget.position;// + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition ,followSpeed* Time.deltaTime);
        transform.LookAt(LookTarget);
    }
}
