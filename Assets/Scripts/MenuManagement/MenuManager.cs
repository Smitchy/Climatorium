using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuManager : MonoBehaviour
{
    private GenericMenuManager gMM;
    private UserPresenceState previousUserPresence;

    private void Awake()
    {
        previousUserPresence = XRDevice.userPresence;
        gMM = GetComponent<GenericMenuManager>();
    }
    private void Start()
    {
        StartCoroutine(SpawnFirstMenu());
    }

    public void DisplayMenu(StateEnum state)
    {
        gMM.ActivateMenu(state);
    }
    private void Update()
    {
        if (XRDevice.userPresence != previousUserPresence)
        {
            if (XRDevice.userPresence == UserPresenceState.NotPresent)
            {
                if (CurrentState.currentState == StateEnum.PuzzleInProgress)
                {
                    DisplayMenu(StateEnum.PauseMenu);
                }
            }
            previousUserPresence = XRDevice.userPresence;
        }
    }
    private IEnumerator SpawnFirstMenu()
    {
        yield return new WaitForSeconds(1f);
        DisplayMenu(StateEnum.MainMenu);
    }
}
