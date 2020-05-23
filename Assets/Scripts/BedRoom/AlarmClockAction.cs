using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClockAction : MonoBehaviour, IAction
{
    public PuzzleManager puzMan;
    public void DoAction()
    {
        GetComponentInChildren<AudioSource>().Stop();
        puzMan.NextPuzzle();
    }
}
