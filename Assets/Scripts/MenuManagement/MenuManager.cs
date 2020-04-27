using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuManager : MonoBehaviour
{
    public MainMenu MMM;
    public PauseMenuManager PMM;
    public PlayerChangeManager PCM;
    public EndGameManager EGM;
    public Camera VRCamera;
    private int startingMask;
    

    private UserPresenceState previousUserPresence;

    private void Awake()
    {
        previousUserPresence = XRDevice.userPresence;
        startingMask = VRCamera.cullingMask;
    }

    public void DisplayMenu(StateEnum state)
    {
        ShowUIOnly();
        switch (state)
        {
            case StateEnum.MainMenu:
                ToggleMainMenu();
                break;
            case StateEnum.PauseMenu:
                TogglePauseMenu();
                break;
            case StateEnum.PlayerChange:
                TogglePlayerChange();
                break;
            case StateEnum.EndGame:
                ToggleEndGameMenu();
                break;
        }
    }
    private void Update()
    {
        if (XRDevice.userPresence != previousUserPresence)
        {
            if (XRDevice.userPresence == UserPresenceState.NotPresent)
            {
                ShowUIOnly();
                PMM.ActivatePause();
            }
            previousUserPresence = XRDevice.userPresence;
        }
    }

    private void ToggleMainMenu()
    {

    }
    private void TogglePlayerChange()
    {

    }
    private void TogglePauseMenu()
    {
        PMM.ToggleMenu();
    }
    private void ToggleEndGameMenu()
    {

    }
    private void ShowUIOnly()
    {
        VRCamera.cullingMask |= 1 << LayerMask.NameToLayer("UI");
        Debug.Log("Showing UI");
    }
    private void ShowEverything()
    {
        VRCamera.cullingMask = startingMask;
    }

}
