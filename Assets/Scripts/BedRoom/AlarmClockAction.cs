using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClockAction : MonoBehaviour, IAction
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DoAction()
    {
        audioSource.Stop();
    }
}
