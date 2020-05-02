using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Zinnia.Pointer.ObjectPointer;

public class CallButtonActions : MonoBehaviour
{
    private EventSystem eventSystem;
    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }
    public void CallButtonAction(EventData eventData)
    {
        if (CurrentState.currentState != StateEnum.PuzzleInProgress && eventData != null)
        {
            Button button = eventData.CollisionData.collider.gameObject.GetComponent<Button>();
            if (button)
            {
                button.onClick.Invoke();
            }
        }
    }
    public void CallHoverActionEnter(EventData eventData)
    {
        if (CurrentState.currentState != StateEnum.PuzzleInProgress && eventData != null)
        {
            Button button = eventData.CollisionData.collider.gameObject.GetComponent<Button>();
            if (button)
            {
                eventSystem.SetSelectedGameObject(button.gameObject);
            }
        }
    }
    public void CallHoverActionExit(EventData eventData)
    {
        if (CurrentState.currentState != StateEnum.PuzzleInProgress && eventData != null)
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }
}
