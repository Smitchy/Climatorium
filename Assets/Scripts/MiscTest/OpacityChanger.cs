using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpacityChanger : MonoBehaviour
{

    Material test;
    
    // Start is called before the first frame update
    void Start()
    {
        test = gameObject.GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Material target, green;
    public void UpdateOpacity(float alphaValue)
    {
        // Color color = target.color;
        // color.a = alphaValue;
        // target.color = color;
        gameObject.GetComponent<MeshRenderer>().material = target;
    }

    public void ChangeToGreen()
    {
        gameObject.GetComponent<MeshRenderer>().material = green;
    }
}
