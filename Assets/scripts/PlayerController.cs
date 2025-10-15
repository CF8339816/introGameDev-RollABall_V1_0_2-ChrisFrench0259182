using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class layerController : MonoBehaviour
{

    private Rigidbody rb;// Rigidbody for MrBall
    private int count;  //Adds a counter

    private float movementX;  // Movement along X axes
    private float movementY;  // Movement along Y axes


    public float speed = 0; // Speed MrBall moves
    public TextMeshProUGUI countText; //creates Count Text obj
    public GameObject winTextObject;  //creates win text obj

    void Start() // Start called before first frame update
    {
        rb = GetComponent<Rigidbody>();  // Get & stores Rigidbody attached to MrBall
        count = 0; // sets counter to 0
        SetCountText(); //updates count
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)  // Function called when movement input detected
    {
        Vector2 movementVector = movementValue.Get<Vector2>();    // Converts input value into Vector2 inputfor movement

        movementX = movementVector.x;// Stores the X movement
        movementY = movementVector.y;// Stores the y movement
    }
      void SetCountText()
       {
           countText.text = "Wayward Capsules Wrangled: " + count.ToString(); // sets count to output to string

           if (count >= 12)  //checks ammount collected
         {
             winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
       }
   



    private void FixedUpdate() // FixedUpdate called once per fixed f-r frame
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);  // Creates 3D move vector using  X and Y input

        rb.AddForce(movement * speed); // Applies force to  Rigidbody to move MrBall
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
            winTextObject.GetComponent<TextMeshProUGUI>().text = "WhaaaaH Waaahhhaaahhhhaaa  You Lose!";
        }
    }
}














