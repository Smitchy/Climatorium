using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Vector3 startPos;

    [SerializeField]
    private Transform toPos;
    [SerializeField]
    private float speed, smoothTime;

    private Vector3 vel = Vector3.zero;


    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, toPos.position,ref vel, smoothTime, step);
        if(transform.position == toPos.position)
        {
            toPos.position = startPos;
            startPos = transform.position;
        }
    }
}
