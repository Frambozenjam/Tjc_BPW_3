using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Player : MonoBehaviour
{
    //Settings
    public float f_MovementSpeed = 3f;
    public float f_SprintSpeedMultiplyer = 1.5f;
    public float f_LookSensitivity_X = 1f;
    public float f_LookSensitivity_Y = 1f;
    public float f_CameraClampAngle = 80f;
    public float f_JumpStrength = 100f;
    public float f_Gravity = -9.81f;

    //Controls
    string Control_SelectSlot_01 = "1";
    string Control_SelectSlot_02 = "2";
    string Control_SelectSlot_03 = "3";
    string Control_LeftClick = "mouse 0";
    string Control_RightClick = "mouse 1";
    string Control_MiddleClick = "mouse 2";

    //References
    public GameObject obj_CameraParent;
    Rigidbody comp_Rigidbody;

    //Changing variables
    Vector3 v3_Velocity = Vector3.zero;
    int i_SelectedSlot = 1;
    float f_CameraRotation_X;
    float f_CameraRotation_Y;
    bool b_MenuOpen = false;
    bool b_Sprinting = false;
    bool b_IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //Set character controller reference
        comp_Rigidbody = GetComponent<Rigidbody>();
        //Hide cursor
        Function_CursorMode("Locked");
        //set camera rotation values
        Vector3 v3_CameraRotation = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Function_InputMovement();
        Function_CheckInputs();
        Function_CheckIfGrounded();
        Function_ApplyMovement();
        Function_Camera();
    }

    void FixedUpdate()
    {
    }

    //Check for inputs
    void Function_CheckInputs()
    {
        //Input for mouse
        if (Input.GetKeyDown(Control_LeftClick)) { Function_LeftClick(); }
        if (Input.GetKeyDown(Control_RightClick)) { Function_RightClick(); }
        if (Input.GetKeyDown(Control_MiddleClick)) { Function_MiddleClick(); }

        if (Input.GetKey(KeyCode.LeftShift)) { b_Sprinting = true; } else { b_Sprinting = false; }

        //UI
        if (Input.GetKeyDown(KeyCode.Escape)) { Function_ToggleMenu(); }

        //Input for selecting slot
        if (Input.GetKeyDown(Control_SelectSlot_01)) { Function_ChangeSelectedSlot(1); };
        if (Input.GetKeyDown(Control_SelectSlot_02)) { Function_ChangeSelectedSlot(2); };
        if (Input.GetKeyDown(Control_SelectSlot_03)) { Function_ChangeSelectedSlot(3); };
    }

    //Left Click
    void Function_LeftClick()
    {
        Debug.Log("Left clicked.");
        if(b_MenuOpen == true)
        {
            Function_ToggleMenu();
        }
    }

    //Right Click
    void Function_RightClick()
    {
        Debug.Log("Right clicked.");
    }

    //Middle Click
    void Function_MiddleClick()
    {
        Debug.Log("Middle clicked.");
    }

    //apply movement speed to velocity from inputs
    void Function_InputMovement()
    {
        float f_Speed = f_MovementSpeed;
        if (b_Sprinting == true)
        {
            f_Speed = f_MovementSpeed * f_SprintSpeedMultiplyer;
        }
        else
        {
            f_Speed = f_MovementSpeed;
        }

        Vector3 v3_Forward = Input.GetAxisRaw("Vertical") * transform.forward;
        Vector3 v3_Right = Input.GetAxisRaw("Horizontal") * transform.right;
        v3_Velocity = (v3_Right + v3_Forward).normalized * f_Speed;

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && b_IsGrounded == true)
        {
            comp_Rigidbody.AddForce(Vector3.up * f_JumpStrength);
        }
    }

    void Function_CheckIfGrounded()
    {
        float f_DistanceToGround = GetComponent<Collider>().bounds.extents.y;
        b_IsGrounded = Physics.Raycast(transform.position, Vector3.down, f_DistanceToGround + 0.1f);
    }

    void Function_ApplyMovement()
    {
        if(v3_Velocity != Vector3.zero)
        {
            comp_Rigidbody.position += v3_Velocity * Time.deltaTime;
        }

        if(b_IsGrounded != true)
        {
            comp_Rigidbody.AddForce(new Vector3(0,f_Gravity,0));
        }

        //reset velocity to prevent sliding
        comp_Rigidbody.velocity = new Vector3(0, comp_Rigidbody.velocity.y, 0);
        comp_Rigidbody.angularVelocity = Vector3.zero;
    }

    //Camera
    void Function_Camera()
    {
        float f_Mouse_X = Input.GetAxis("Mouse X");
        float f_Mouse_Y = -Input.GetAxis("Mouse Y");

        f_CameraRotation_X += f_Mouse_X * f_LookSensitivity_X * Time.deltaTime;
        f_CameraRotation_Y += f_Mouse_Y * f_LookSensitivity_Y * Time.deltaTime;

        f_CameraRotation_Y = Mathf.Clamp(f_CameraRotation_Y, -f_CameraClampAngle, f_CameraClampAngle);

        obj_CameraParent.transform.localRotation = Quaternion.Euler(f_CameraRotation_Y, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, f_CameraRotation_X, 0.0f);
    }

    //Interact Raycast
    public GameObject Function_Raycast(float f_RayDistance)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Debug show raycast
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward * f_RayDistance);
        Debug.DrawRay(Camera.main.transform.position, forward, Color.red, 1, false);

        //Continue if something is hit.
        if (Physics.Raycast (ray, out hit, f_RayDistance))
        {
            Debug.Log("Object raycasthit: " + hit.collider.name);
            return hit.collider.gameObject;
        }
        return null;
    }

    //Change selected slot
    void Function_ChangeSelectedSlot(int i_SlotToSelect)
    {
        i_SelectedSlot = i_SlotToSelect;
        Debug.Log("Slot " + i_SelectedSlot + " selected.");
    }

    //Change cursor visibility
    void Function_CursorMode(string s_CursorMode)
    {
        if(s_CursorMode == "Unlocked")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(s_CursorMode == "Locked")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    //Menu
    void Function_ToggleMenu()
    {
        if(b_MenuOpen == true)
        {
            //close menu and hide cursor
            Function_CursorMode("Locked");
            b_MenuOpen = false;
        }
        else if(b_MenuOpen == false)
        {
            //open menu and show cursor
            Function_CursorMode("Unlocked");
            b_MenuOpen = true;
        }
    }
}