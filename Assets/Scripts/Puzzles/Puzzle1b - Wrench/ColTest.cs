using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColTest : MonoBehaviour
{

    public TMP_Text test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //test.text = other.name;
    }

}
