using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerActions : MonoBehaviour
{
    private EventSystem eventSystem;
    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }
    public void OnPress()
    {
        GetComponent<Button>().onClick.Invoke();
    }
    public void OnHighlightEnter()
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }
    public void OnHighlightExit()
    {
        eventSystem.SetSelectedGameObject(null);
    }
}
