using System;
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
        if ((pipeTag.Equals("Straight") && straightPipeSnapZoneExited) || (pipeTag.Equals("Corner") && cornerPipeSnapZoneExited)) 
        { FindPipe(pipeTag); }
    }

    private void FindPipe(String tag)
    {
        foreach (GameObject pipe in pipes)
            {
                if (pipe.tag.Equals(tag) && !pipe.activeInHierarchy)
                {
                    if (tag.Equals("Straight"))
                    {
                        straightPipeSnapZoneExited = false;
                        straightPipeSnapZoneFacade.Snap(pipe);
                    }

                    else
                    {
                        cornerPipeSnapZoneExited = false;
                        cornerPipeSnapZoneFacade.Snap(pipe);
                    }

                    pipe.GetComponent<Rigidbody>().isKinematic = false;
                    pipe.SetActive(true);
                    return;
                }
            }
    }

    public void ResetPipePosition(GameObject pipe)
    {
        Debug.Log("Straight pipe snap zone exited: " + straightPipeSnapZoneExited);
        if (pipe.tag.Equals("Straight") && straightPipeSnapZoneExited)
        { straightPipeSnapZoneFacade.Snap(pipe); }

        else if (pipe.tag.Equals("Corner") && cornerPipeSnapZoneExited)
        { cornerPipeSnapZoneFacade.Snap(pipe); }

        else
        { pipe.SetActive(false); }
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
