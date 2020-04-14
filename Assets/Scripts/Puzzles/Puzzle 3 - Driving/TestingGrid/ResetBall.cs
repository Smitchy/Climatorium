using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    private Vector3 startPos;
    private void Start()
    {
        startPos = gameObject.transform.position;
    }
    public void ResetGO()
    {
        gameObject.transform.position = startPos;
    }
}
