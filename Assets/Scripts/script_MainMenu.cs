using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_MainMenu : MonoBehaviour
{
    private void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void Function_Play()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("scene_Main");
    }

    public void Function_Quit()
    {
        Application.Quit();
    }

    public void Function_MainMenu()
    {
        SceneManager.LoadScene("scene_Menu");
    }
}
