using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterpuzzleIPuzzle : iPuzzle
{
    public GameObject ground;
    public PipeManager pipeMan;
    public override void SetUp()
    {
        gameObject.SetActive(true);
        GroundCollisionHandler GCH = ground.AddComponent<GroundCollisionHandler>();
        GCH.pipeManager = pipeMan;
        
    }

    public override void TearDown()
    {
        gameObject.SetActive(false);
        Destroy(ground.GetComponent<GroundCollisionHandler>());
    }

}
