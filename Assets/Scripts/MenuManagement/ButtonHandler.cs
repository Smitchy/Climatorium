using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public GenericMenuManager genericMenuManager;
    private enum CallingMenu { Main, Pause};
    private CallingMenu callingMenu;
    public enum ButtonEnum { Main_Play, Main_Options, Main_Hiscores, Main_Quit, Options_Back }

    public void HandleButton(string button)
    {
        switch (button)
        {
            case "Main/Play":
                genericMenuManager.DeactivateMenu();
                puzzleManager.NextPuzzle();
                break;
            case "Main/Options":
                genericMenuManager.ActivateMenu(StateEnum.OptionsMenu);
                callingMenu = CallingMenu.Main;
                break;
            case "Main/Hiscores":
                genericMenuManager.ActivateMenu(StateEnum.HiscoresMenu);
                callingMenu = CallingMenu.Main;
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
        }
    }
}
