using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public Canvas pauseMenu;
    private bool activated;

    public void ToggleMenu()
    {
        if (activated)
            DeactivatePause();
        else
            ActivatePause();
    }
    public void ActivatePause()
    {
        if (!activated)
        {
            /*Time.timeScale = 0;*/
            pauseMenu.gameObject.SetActive(true);
            CurrentState.SetStateStart(StateEnum.PauseMenu);
            Debug.Log("Activating pause");
            activated = true;
        }

    }
    public void DeactivatePause()
    {
        if (activated)
        {
            /*Time.timeScale = 1;*/
            pauseMenu.gameObject.SetActive(false);
            CurrentState.SetStateEnd();
            Debug.Log("Deactivating pause");
            activated = false;
        }

    }
}
