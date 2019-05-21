using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Interact : MonoBehaviour
{
    //public
    public float f_InteractionDistance = 5f;
    public float f_ThrowForce = 500f;
    public float f_LerpSmooth = 1f;
    public bool b_HoldingObject = false;
    public bool b_CanInteract = true;
    public GameObject obj_Interactable;
    public GameObject obj_TempParrent;

    Vector3 v3_ObjectPos = Vector3.zero;
    FixedJoint comp_FixedJoint;
    private void Start()
    {
        comp_FixedJoint = obj_TempParrent.GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Function_Interact();
        }
    }

    private void FixedUpdate()
    {
        if (b_HoldingObject)
        {
            b_CanInteract = false;
            Function_UpdateCarriedObject();

            if (Input.GetMouseButton(1))
            {
                //Throw
            }
        }
        else b_CanInteract = true;
    }

    //Try to interact
    void Function_Interact()
    {
        Debug.Log("Interact pressed.");

        if (b_CanInteract)
        {
            obj_Interactable = GetComponent<script_Player>().Function_Raycast(f_InteractionDistance);

            if (obj_Interactable != null)
            {
                //For interacting with the wisp
                if (obj_Interactable.GetComponent<script_Interaction_Wisp>() != null)
                {
                    script_Interaction_Wisp comp_script_Interaction_Wisp = obj_Interactable.GetComponent<script_Interaction_Wisp>();
                    comp_script_Interaction_Wisp.function_Interaction();
                }

                //For picking up an object
                if (obj_Interactable.gameObject.tag == "tag_Interactable")
                {
                    obj_Interactable.GetComponent<Rigidbody>().useGravity = false;
                    //obj_Interactable.transform.SetParent(obj_TempParrent.transform);
                    b_HoldingObject = true;
                    Debug.Log("This object is interactable. Holding Object.");
                }
                else
                {
                    Debug.Log("This object is not interactable.");
                }
            }
        }
        else if(b_HoldingObject)
        {
            obj_Interactable.GetComponent<Rigidbody>().useGravity = true;
            //obj_Interactable.transform.SetParent(null);
            b_HoldingObject = false;
            Debug.Log("Dropped Object due to interact pressed.");
        }
    }

    //Update carried object
    void Function_UpdateCarriedObject()
    {
        //Set velocity to 0
        obj_Interactable.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj_Interactable.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //Keep position at handle
        //obj_Interactable.transform.position = obj_TempParrent.transform.position;
        //obj_Interactable.transform.position = Vector3.MoveTowards(obj_Interactable.transform.position, obj_TempParrent.transform.position, Time.deltaTime * (f_LerpSmooth));
        //obj_Interactable.transform.position = Vector3.Lerp(obj_Interactable.transform.position, obj_TempParrent.transform.position, Time.fixedDeltaTime * f_LerpSmooth);
        obj_Interactable.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(obj_Interactable.transform.position, obj_TempParrent.transform.position, Time.fixedDeltaTime * f_LerpSmooth));
    } 
}
