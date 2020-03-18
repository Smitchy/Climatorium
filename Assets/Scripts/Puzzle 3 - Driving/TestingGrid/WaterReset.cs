using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ResetBall>())
        {
            Debug.Log("Ball entered");
            col.GetComponent<ResetBall>().ResetGO();
        }
    }
}
