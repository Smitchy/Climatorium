using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingPuzzle : iPuzzle
{
    public override void SetUp()
    {
        gameObject.SetActive(true);
    }
    public override void TearDown()
    {
        //gameObject.GetComponentInChildren<ResetBall>().ResetGO();
        gameObject.SetActive(false);
    }
}