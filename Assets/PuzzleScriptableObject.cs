using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//different materials found on the periodic table with their own placement imbedded?
public enum prefabMaterials { IRON = 26, URANIUM = 92, ALUMINIUM  = 13, GOLD = 79 }
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PuzzleScriptableObject", order = 1)]
public class PuzzleScriptableObject : ScriptableObject
{
    
    public prefabMaterials materialTypeName;
    //public string prefabName;
    public float weightGrams, gramsPerUnit,density;



}
