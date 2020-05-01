using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
    public void ChangeToUntagged()
    {
        gameObject.tag = "Untagged";
    }

    public void ChangeToFood()
    {
        gameObject.tag = "Food";
    }
}
