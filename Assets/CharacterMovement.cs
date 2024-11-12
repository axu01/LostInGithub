using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // This project is the Lighting and Animation package from the Unity Creative Core Pathway.
    // I put the movement code in here for the fun of it.... 
    // You can use the original scene with the complex camera movement script 
    // This script is based on Brackey's tutorial (the one I gave you in class)
    // TODO: My character nevr becoes grounded

    [SerializeField]
    float x;
    [SerializeField]
    float z;
    
    Vector3 moveDirection;
    public float Speed = 10;

    [SerializeField]
    Vector3 velocity;
    
    public float Gravity;
    // Creating our own Groundcheck bool
    [SerializeField]
    bool Grounded = true;
    public Transform GroundCheck;
    public float CheckingRadius;
    public LayerMask groundMask;

    // Declare a CharacterController variable
    // Assign the value of this variable in the Unity Editor
    public CharacterController Controller;


    // Update is called once per frame
    void Update()
    {
        // print(Controller.detectCollisions);  // is set to true by default but I wanted to check

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // transform.right takes the _local_ transform of the GO 
        moveDirection = transform.right * x + transform.forward * z;

        Controller.Move(moveDirection * Speed * Time.deltaTime);

        // Groundcheck everyframe
        Grounded = Physics.CheckSphere(GroundCheck.position, CheckingRadius, groundMask);

        print(Grounded+ "     = Grounded in Update() CharacterMovement.cs");

                        // TODO: Grounded is always false again! 
                        // and TODO: What is determining Y position of character??

        // If we are not touching the ground, apply acceleration of gravity
        if(!Grounded)   
        {
            velocity.y += Gravity * Time.deltaTime;
        }
        if(Grounded && velocity.y < 0) // if we are on our way down from a jump
        {
            velocity.y = -0.2f;  // 
        }

        // Calling Move() a second time each frame (not so nice but this is a prototype!)
        Controller.Move(velocity * Time.deltaTime);
   

        // Investigating Collisions with CharacterController  This code is from Unity's Documentation page about CollisionFlags
        // Using this to diagnose a lack of collisions is helpful   I made my CharController bigger and that helped.
       
        if (Controller.collisionFlags == CollisionFlags.None)
        {
            print("Free floating!");
        }

        if ((Controller.collisionFlags & CollisionFlags.Sides) != 0)
        {
            print("Touching sides!");
        }

        if (Controller.collisionFlags == CollisionFlags.Sides)
        {
            print("Only touching sides, nothing else!");
        }

        if ((Controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            print("Touching Ceiling!");
        }

        if (Controller.collisionFlags == CollisionFlags.Above)
        {
            print("Only touching Ceiling, nothing else!");
        }

        if ((Controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            print("Touching ground!");
        }

        if (Controller.collisionFlags == CollisionFlags.Below)
        {
            print("Only touching ground, nothing else!");
        }
    }

   // This is how we do thiings on Collisions when using a CharacterController
   void OnControllerColliderHit(ControllerColliderHit hit)
   {
        // Print out the name of the object we ran into
        print(hit.gameObject+ "In OnControllerColliderHit()  and flags:  "+ Controller.collisionFlags);
   }

}
