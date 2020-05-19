using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSound : MonoBehaviour
{
    private SoundPoolMan soundPoolMan;
    public AudioClip alarm;

    private void Awake()
    {
        soundPoolMan = FindObjectOfType<SoundPoolMan>();
    }
    void Start()
    {
        soundPoolMan.SetupSoundPlayer(alarm, gameObject, true);
    }
}
