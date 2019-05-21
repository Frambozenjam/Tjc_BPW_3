using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class class_Sound
{
    public string s_Name;

    public AudioClip ac_AudioClip;

    [Range(0f, 1f)]
    public float f_Volume;
    [Range(.1f, 1f)]
    public float f_Pitch;

    public float f_FalloffStartRange = 3;
    public bool b_Loop;
    public float f_StartTime;
    public float f_DopplerLevel = 0;
    public float f_3DSpread = 100;



    [HideInInspector]
    public AudioSource as_AudioSource;
}
