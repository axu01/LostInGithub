using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    //private Rigidbody rb;
    //private float movementX;
    //private float movementY;
    // Start is called before the first frame update
    //void Start()
    //{
        //rb = GetComponent<Rigidbody>();
    //}
   
    //void OnMove(InputValue movementValue)
    //{
        //Vector2 movementVector = movementValue.Get<Vector2>();
        //movementX = movementVector.x;
        //movementY = movementVector.y;
    //}
    private void FixedUpdate()
    {
        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //rb.AddForce(movement * speed);
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");
        Vector3 MoveBall = new Vector3(HorizontalMovement, 0, VerticalMovement);
        gameObject.transform.GetComponent<Rigidbody>().AddForce(MoveBall * Speed);
    }

    // Update is called once per frame

}