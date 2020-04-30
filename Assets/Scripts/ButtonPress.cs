using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public void ButtonPressed()
    {
        Debug.Log(gameObject.name + " button pressed.");
    }
}
