﻿using System;
using UnityEngine;
using VRTK.Prefabs.Interactions.InteractableSnapZone;

public class PipeManager : MonoBehaviour
{
    public GameObject[] pipes;
    public SnapZoneFacade straightPipeSnapZoneFacade;
    public SnapZoneFacade cornerPipeSnapZoneFacade;
    private bool straightPipeSnapZoneExited;
    private bool cornerPipeSnapZoneExited;

    public void SpawnNextPipe(string pipeTag)
    {
        if (pipeTag.Equals("Straight") && straightPipeSnapZoneExited) 
        { FindPipe(pipeTag); }

        else if (pipeTag.Equals("Corner") && cornerPipeSnapZoneExited) 
        { FindPipe(pipeTag); }
    }

    private void FindPipe(String tag)
    {
        foreach (GameObject pipe in pipes)
            {
                if (pipe.tag.Equals(tag) && !pipe.activeInHierarchy)
                {
                    if (tag.Equals("Straight")) straightPipeSnapZoneExited = false; else cornerPipeSnapZoneExited = false;
                    pipe.SetActive(true);
                    return;
                }
            }
    }

    public void ResetPipePosition(GameObject pipe)
    {
        if (pipe.tag.Equals("Straight"))
        { straightPipeSnapZoneFacade.Snap(pipe); }

        else
        { cornerPipeSnapZoneFacade.Snap(pipe); }
    }

    public void SetStraightSnapZoneExited(bool value)
    {
        straightPipeSnapZoneExited = value;
    }

    public void SetCornerSnapZoneExited(bool value)
    {
        cornerPipeSnapZoneExited = value;
    }
}
