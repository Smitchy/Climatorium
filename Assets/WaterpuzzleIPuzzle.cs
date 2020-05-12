using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterpuzzleIPuzzle : iPuzzle
{
    public override void SetUp()
    {
        gameObject.SetActive(true);
    }

    public override void TearDown()
    {
        gameObject.SetActive(true);
    }

}
