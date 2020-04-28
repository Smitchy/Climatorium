using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class GenericMenuManager : MonoBehaviour
{
    private bool activated;
    private int startingMask;
    public Camera VRCamera;
    public GameObject MainMenu, PauseMenu, PlayerChangeMenu, EndGameMenu, Options;
    private GameObject currentMenu;
    private BooleanAction boolAction;

    private void Awake()
    {
        startingMask = VRCamera.cullingMask;
    }
    public void ActivateMenu(StateEnum menu)
    {
        if (!activated)
        {
            ShowUIOnly();
            Time.timeScale = 0;
            boolAction.Receive(true);
            switch (menu)
            {
                case StateEnum.MainMenu:
                    MainMenu.SetActive(true);
                    currentMenu = MainMenu;
                    CurrentState.SetStateStart(StateEnum.MainMenu);
                    break;
                case StateEnum.PauseMenu:
                    PauseMenu.SetActive(true);
                    currentMenu = PauseMenu;
                    CurrentState.SetStateStart(StateEnum.PauseMenu);
                    break;
                case StateEnum.PlayerChange:
                    PlayerChangeMenu.SetActive(true);
                    currentMenu = PlayerChangeMenu;
                    CurrentState.SetStateStart(StateEnum.PlayerChange);
                    break;
                case StateEnum.EndGame:
                    EndGameMenu.SetActive(true);
                    currentMenu = EndGameMenu;
                    CurrentState.SetStateStart(StateEnum.EndGame);
                    break;
                case StateEnum.OptionsMenu:
                    currentMenu.SetActive(false);
                    Options.SetActive(true);
                    currentMenu = Options;
                    CurrentState.SetStateStart(StateEnum.OptionsMenu);
                    break;
            }            
            Debug.Log("Activating " + menu);
            activated = true;
        }
    }
    public void DeactivateMenu()
    {
        if (activated && currentMenu != null)
        {
            boolAction.Receive(true);
            currentMenu.SetActive(false);
            currentMenu = null;
            ShowEverything();
            Time.timeScale = 1;
            Debug.Log("Deactivating " + CurrentState.currentState);
            CurrentState.SetStateEnd();
            activated = false;
        }
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
