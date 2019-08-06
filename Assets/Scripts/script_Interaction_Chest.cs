using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_Interaction_Chest : MonoBehaviour
{
    script_ac compScript_ac;
    script_ManagerAudio compScript_ManagerAudio;
    AudioSource compAudioSource;

    public GameObject obj_TextVictory;
    public GameObject obj_TextInstruction;

    float f_Countdown = 1;

    private void Start()
    {
        compScript_ac = GetComponent<script_ac>();
        compScript_ManagerAudio = GetComponent<script_ManagerAudio>();
        compAudioSource = GetComponent<AudioSource>();
    }

    public void function_Interaction()
    {
        compScript_ac.bool_Toggle = !compScript_ac.bool_Toggle;
        compScript_ManagerAudio.Function_PlayAudio("au_ChestOpen");
        compAudioSource.volume = 1;
        obj_TextVictory.SetActive(true);
        obj_TextInstruction.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (compAudioSource.volume > 0)
        {
            compAudioSource.volume = f_Countdown;
            if (f_Countdown <= 0)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("scene_MenuVictory");
            }
            f_Countdown = f_Countdown -0.003f;
        }
    }
}
