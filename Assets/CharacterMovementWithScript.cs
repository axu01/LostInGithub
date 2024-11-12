using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementWithScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator myAnimatorController;
    // for moving
    private Vector3 Direction;
    private CharacterController myCharacterController;
    void Start()
    {
        // For animating our character
        myAnimatorController = GetComponentInChildren<Animator>();
        // for moving our chacter
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Jump Pressed");
            myAnimatorController.SetBool("E", false);
        }
        //If no longer pressing shift
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("Jump false");
            myAnimatorController.SetBool("E", true);
        }

    }

  
}
