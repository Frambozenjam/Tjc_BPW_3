using UnityEngine;

public class script_AudioCaller : MonoBehaviour
{
    GameObject ref_ManagerAudio;

    private void Start()
    {
        ref_ManagerAudio = GameObject.Find("ManagerAudio");
    }

    public void Function_PlayAudio(string name)
    {
        ref_ManagerAudio.GetComponent<script_ManagerAudio>().Function_PlayAudio(name);
    }
    public void Function_StopAudio(string name)
    {
        ref_ManagerAudio.GetComponent<script_ManagerAudio>().Function_StopAudio(name);
    }
}
