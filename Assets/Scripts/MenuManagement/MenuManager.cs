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

    private UserPresenceState previousUserPresence;

    private void Awake()
    {
        previousUserPresence = XRDevice.userPresence;
    }

    public void DisplayMenu(StateEnum state)
    {
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

}
