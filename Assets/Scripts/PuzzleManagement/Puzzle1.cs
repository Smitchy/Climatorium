using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Example of a puzzle implementation
public class Puzzle1 : iPuzzle
{

    public override void SetUp()
    {
        Debug.Log("Puzzle 1 set up");
    }

    public override void TearDown()
    {
        Debug.Log("Puzzle 1 tear down");
    }
}
