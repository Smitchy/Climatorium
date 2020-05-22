using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public GenericMenuManager genericMenuManager;
    private enum CallingMenu { Main, Pause};
    private CallingMenu callingMenu;
    public SoundPoolMan soundManager;

    public void HandleButton(string button)
    {
        switch (button)
        {
            case "Main/Play":
                genericMenuManager.DeactivateMenu();
                CurrentState.currentState = StateEnum.PuzzleInProgress;
                puzzleManager.NextPuzzle();
                break;
            case "Main/Options":
                genericMenuManager.ActivateMenu(StateEnum.OptionsMenu);
                callingMenu = CallingMenu.Main;
                break;
            case "Main/Hiscores":
                genericMenuManager.ActivateMenu(StateEnum.HiscoresMenu);
                break;
            case "Main/Quit":
                //quit logic
                break;
            case "Options/Back":
                switch (callingMenu)
                {
                    case CallingMenu.Main:
                        genericMenuManager.ActivateMenu(StateEnum.MainMenu);
                        break;
                    case CallingMenu.Pause:
                        genericMenuManager.ActivateMenu(StateEnum.PauseMenu);
                        break;
                }
                break;
            case "Options/VolumeDown":
                DecrementVolume();
                break;
            case "Options/VolumeUp":
                IncrementVolume();
                break;
            case "HiScores/Back":
                genericMenuManager.ActivateMenu(StateEnum.MainMenu);
                break;
            case "Pause/Resume":
                genericMenuManager.DeactivateMenu();
                break;
            case "Pause/Options":
                callingMenu = CallingMenu.Pause;
                genericMenuManager.ActivateMenu(StateEnum.OptionsMenu);
                break;
        }
    }
    private void IncrementVolume()
    {
        soundManager.IncreaseVolume();
    }
    private void DecrementVolume()
    {
        soundManager.DecreaseVolume();
    }
}
