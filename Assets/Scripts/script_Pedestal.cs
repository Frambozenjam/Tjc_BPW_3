using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Pedestal : MonoBehaviour
{
    //public variables
    public Material mat_DeActivated;
    public Material mat_Activated;
    public GameObject obj_RequiredKey;
    public bool b_isActivated;

    //References
    Material[] mat_Array;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == obj_RequiredKey.name && b_isActivated == false)
        {
            b_isActivated = true;
            mat_Array = GetComponent<Renderer>().materials;
            mat_Array[1] = mat_Activated;
            GetComponent<Renderer>().materials = mat_Array;
            GetComponent<script_ManagerAudio>().Function_PlayAudio("s_PedestalActivate");
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.name == obj_RequiredKey.name)
    //    {
    //        b_isActivated = false;
    //        mat_Array = GetComponent<Renderer>().materials;
    //        mat_Array[1] = mat_DeActivated;
    //        GetComponent<Renderer>().materials = mat_Array;
    //    }
    //}
}
