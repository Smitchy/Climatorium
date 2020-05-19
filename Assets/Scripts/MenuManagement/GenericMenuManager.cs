using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class GenericMenuManager : MonoBehaviour
{
    private int startingMask;
    public Camera VRCamera;
    public GameObject headsetAlias;
    public float menuOffset;
    public GameObject MainMenu, PauseMenu, PlayerChangeMenu, EndGameMenu, Options, HiScores, MainCanvas;
    public GameObject laser;
    private GameObject currentMenu;
    private BooleanAction boolAction;
    private GameObject[] canvasRefs;
    [SerializeField]
    private LayerMask menuLayer;
    private SoundPoolMan soundPoolMan;

    private void Awake()
    {
        startingMask = VRCamera.cullingMask;
        soundPoolMan = FindObjectOfType<SoundPoolMan>();
        boolAction = GetComponent<BooleanAction>();
        MainCanvas.transform.position = headsetAlias.transform.position + headsetAlias.transform.forward * menuOffset;
        canvasRefs = new GameObject[] { MainMenu, PauseMenu, PlayerChangeMenu, EndGameMenu, Options, HiScores };
    }
    public void ActivateMenu(StateEnum menu)
    {

        //MainCanvas.transform.position = headsetAlias.transform.position + headsetAlias.transform.forward * menuOffset;
        ShowUIOnly();
        boolAction.Receive(true);
        DisableAllMenus();
        switch (menu)
        {
            case StateEnum.MainMenu:
                MainMenu.SetActive(true);
                currentMenu = MainMenu;
                CurrentState.SetStateStart(StateEnum.MainMenu);
                soundPoolMan.PauseAllSounds();
                break;
            case StateEnum.PauseMenu:
                PauseMenu.SetActive(true);
                currentMenu = PauseMenu;
                CurrentState.SetStateStart(StateEnum.PauseMenu);
                soundPoolMan.PauseAllSounds();
                break;
            case StateEnum.OptionsMenu:
                currentMenu.SetActive(false);
                Options.SetActive(true);
                currentMenu = Options;
                CurrentState.SetStateStart(StateEnum.OptionsMenu);
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

            case StateEnum.HiscoresMenu:
                HiScores.SetActive(true);
                currentMenu = HiScores;
                CurrentState.SetStateStart(StateEnum.HiscoresMenu);
                break;

        }
        Debug.Log("Activating " + menu);
    }
    public void DeactivateMenu()
    {
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
            currentMenu = null;
            ShowEverything();
            Time.timeScale = 1;
            CurrentState.SetStateEnd();
            soundPoolMan.ResumeAllSounds();
        }
    }
    private void ShowUIOnly()
    {
        VRCamera.cullingMask = menuLayer;
        laser.SetActive(true);
        Debug.Log("Showing UI");
        Time.timeScale = 0;
    }
    private void ShowEverything()
    {
        laser.SetActive(false);
        VRCamera.cullingMask = startingMask;
    }
    private void DisableAllMenus()
    {
        foreach (GameObject go in canvasRefs)
        {
            go.SetActive(false);
        }
    }
}
