using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Interaction_Chest : MonoBehaviour
{
    script_ac compScript_ac;
    private void Start()
    {
        compScript_ac = GetComponent<script_ac>();
    }

    public void function_Interaction()
    {
        compScript_ac.bool_Toggle = !compScript_ac.bool_Toggle;
    }
}
