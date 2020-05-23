using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClockAction : MonoBehaviour, IAction
{

    public void DoAction()
    {
        GetComponentInChildren<AudioSource>().Stop();
    }
}
