using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ArtiControler : MonoBehaviour
{
  
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

   
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);


    }

 
    void OnMove(InputValue movementValue)
    {
    
        Vector2 movementVector = movementValue.Get<Vector2>();

   
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Lost ARTI units recovered: " + count.ToString(); // sets count to output to string

        if (count >= 9)  //checks ammount collected
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }


    private void FixedUpdate()
    {
   
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);


        if (movement != Vector3.zero)

            //  transform.rotation = Quaternion.LookRotation(movement); // basic snapped rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f); //smooths out rotation 
  

          transform.Translate(movement * speed * Time.deltaTime, Space.World);


        rb.AddForce(movement * speed);
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) //checks obj ffor PickUp tag
        {
            other.gameObject.SetActive(false); //deactivates obj when collided

            count++; //adds 1 to count when picked up
            SetCountText();   //calls SetCountText method
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);// Destroy player object

            winTextObject.gameObject.SetActive(true);              // Update the winText for loss
            winTextObject.GetComponent<TextMeshProUGUI>().text = " Pirates win Mission Failed";
        }
    }

}