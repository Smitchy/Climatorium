using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    public void UpdateText(float value)
    {
        GetComponent<Text>().text = value.ToString();
    }
}