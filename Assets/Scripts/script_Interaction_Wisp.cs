using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Interaction_Wisp : MonoBehaviour
{
    script_ai_FollowPath comp_script_ai_FollowPath;

    private void Awake()
    {
        comp_script_ai_FollowPath = gameObject.GetComponent<script_ai_FollowPath>();
    }

    public void function_Interaction()
    {
        comp_script_ai_FollowPath.b_Paused = false;
    }
}
