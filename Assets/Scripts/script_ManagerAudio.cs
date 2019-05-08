using UnityEngine.Audio;
using System;
using UnityEngine;

public class script_ManagerAudio : MonoBehaviour
{

    public class_Sound[] Sounds;

    void Awake()
    {

        foreach (class_Sound s in Sounds)
        {
            s.as_AudioSource = gameObject.AddComponent<AudioSource>();
            s.as_AudioSource.clip = s.ac_AudioClip;
            s.as_AudioSource.volume = s.f_Volume;
            s.as_AudioSource.pitch = s.f_Pitch;
            s.as_AudioSource.loop = s.b_Loop;
            s.as_AudioSource.time = s.f_StartTime;
            //s.as_AudioSource.maxDistance = s.f_Range;
            //s.as_AudioSource.rolloffMode = AudioRolloffMode.Linear;
            s.as_AudioSource.spatialBlend = 1f;
        }
    }

    public void Function_PlayAudio (string name)
    {
        class_Sound s = Array.Find(Sounds, Class_Sound => Class_Sound.s_Name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist.");
            return;
        }
        s.as_AudioSource.Play();
    }

    public void Function_StopAudio (string name)
    {
        class_Sound s = Array.Find(Sounds, Class_Sound => Class_Sound.s_Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not playing.");
            return;
        }
        s.as_AudioSource.Stop();
    }
}
