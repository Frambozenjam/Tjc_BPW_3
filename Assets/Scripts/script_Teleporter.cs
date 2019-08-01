using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Teleporter : MonoBehaviour
{
    script_Player comp_script_Player;
    public string string_SceneToLoad;

    private void Awake()
    {
        comp_script_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<script_Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            comp_script_Player.Function_LoadScene(string_SceneToLoad);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
