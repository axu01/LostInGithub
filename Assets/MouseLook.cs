using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float mouseX;
    [SerializeField]
    private float mouseY;
    [SerializeField]
    private float mouseSensitivityX = 100f;
     [SerializeField]
    private float mouseSensitivityY = 100f;
    public float YClampAmount = 90;

    [SerializeField]
    private float xRotation;

    public Transform PlayerBody;
    public bool LockCursor;

    [Header("When Player wants to click on UI")]
    public bool ReleaseCamera;

    public GameObject UIOverlay;


    // Start is called before the first frame update
    void Start()
    {
        // Use this for locking/Unlocking the cursor and turning the UI ON/OFF at same time
        if(LockCursor == true)// you can change this bool in the editor
        {
            Cursor.lockState = CursorLockMode.Locked;

            UIOverlay.SetActive(false); // Comment line out if you don't want to turn a GO on/Off
        }
        else
        {

            Cursor.lockState = CursorLockMode.None;

            UIOverlay.SetActive(true); 

        }

    }

    // Update is called once per frame
    void Update()
    {
        // If Cursor is locked, then use it to move the canmera, if not, don't
        if(ReleaseCamera == false)  // is false when 
        {
            // Gather player Mouse input each frame
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

            // Rotation on the Y only for the PlayerBody (the parentGO)
            // Rotate the player parent on the Y axis according to mouseX input
            PlayerBody.Rotate(Vector3.up * mouseX);

            // Rotate the camera, child of PlayerBody, on the X axis according to the MouseY input
            // FIrst get the current float value for how much we should have rotated 
            xRotation -= mouseY;
            // Then Clamp this value to limit how high and how low player can look
            xRotation = Mathf.Clamp(xRotation, -YClampAmount, YClampAmount);
            // Apply the rotation to thisGO = the camers, a child of the PlayerBody
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        // Toggle CursorLock with Shift Keys
        if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift))
        {
            ToggleCursorLock();
        }
    }


    // The Shift keys will toggle cursor locking
    public void ToggleCursorLock()
    {
        print("ToggleCursorLocl() Top of method!!  "+Cursor.lockState);

        if(Cursor.lockState == CursorLockMode.Locked)  // The cursor is locked, so we are UNLOCKING IT
        {
            // UNLOCK Cursor
            Cursor.lockState = CursorLockMode.None;
            
            // Turn ON the UI Overlay
            UIOverlay.SetActive(true);

            // Stop moving camera with the mouse so player can click on UI buttons
            ReleaseCamera = true;  // Yes, release camera from MouseControl!

            print("UI IS UP, MOUSE RELEASED and this should say true: " + UIOverlay.activeSelf);

        }  

        else if (Cursor.lockState == CursorLockMode.None)  // The cursor is not locked
        {
            // Lock the cursor
            Cursor.lockState = CursorLockMode.Locked;

            // Turn on the UI Overlay
            UIOverlay.SetActive(true);

            // Start moving the camra with mouse again
            ReleaseCamera = false;  //No, do not release Camera, keep MouseControl!

            print("UI IS Off MOUSE LOCKED");

        }   
    }
}


