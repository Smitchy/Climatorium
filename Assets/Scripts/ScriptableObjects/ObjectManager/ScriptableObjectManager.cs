using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectManager : MonoBehaviour
{
    [SerializeField]
    private string name, secretName;
    [SerializeField]
    private float weight, weightPerUnit;
    [SerializeField]
    private int periodicNumber;

    [SerializeField]
    private PuzzleScriptableObject mysteryItem;
    // Start is called before the first frame update
    void Start()
    {
        secretName = mysteryItem.materialTypeName.ToString(); 
        name = "Mystery item";
        gameObject.name = name;


        //gets the integer value from the enum, which should correlate to it's periodic placement 
        periodicNumber = (int)mysteryItem.materialTypeName;
     
    }


    public void CorrectAnswer()
    {
        gameObject.name = secretName;
    }
  
}
