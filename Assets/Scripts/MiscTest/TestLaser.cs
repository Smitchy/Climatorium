using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLaser : MonoBehaviour
{

    public Renderer thing;
    public Material red, green, something,standard;
    public bool switching;
    // Start is called before the first frame update
    void Start()
    {
        standard = thing.material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchBool()
    {
        switching = !switching;
    }

    public void ChangeCol()
    {
        switching = !switching;
        if (switching)
        {
            thing.material = green;
        }
        else
            thing.material = green;
    }

    public void EnteringTheThing()
    {
        thing.material = something;
    }

    public void exits()
    {
        thing.material = standard;
    }
}
