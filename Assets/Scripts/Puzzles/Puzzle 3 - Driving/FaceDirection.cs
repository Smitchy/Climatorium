using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{
    private enum Direction { North, East, South, West };
    private Direction currentDirection;

    private float previousFrameZ;
    private float previousFrameX;
    private Vector3 previousFramePosition;

    public float distanceBeforeRotation;

    // Start is called before the first frame update
    void Start()
    {
        previousFrameZ = transform.position.z;
        previousFrameX = transform.position.x;
        currentDirection = Direction.North;
        previousFramePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckZDistance())
        {
            if (transform.position.z > previousFrameZ && currentDirection != Direction.North)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                currentDirection = Direction.North;
            }
            if (transform.position.z < previousFrameZ && currentDirection != Direction.South)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                currentDirection = Direction.South;
            }
            previousFrameX = transform.position.x;
            previousFrameZ = transform.position.z;
        }
        if (CheckXDistance())
        {
            if (transform.position.x > previousFrameX && currentDirection != Direction.East)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                currentDirection = Direction.East;
            }
            if (transform.position.x < previousFrameX && currentDirection != Direction.West)
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
                currentDirection = Direction.West;
            }
            previousFrameX = transform.position.x;
            previousFrameZ = transform.position.z;

        }

    }

    private bool CheckZDistance()
    {
        if (Mathf.Abs(transform.position.z - previousFrameZ) > distanceBeforeRotation)
            return true;
        return false;
    }
    private bool CheckXDistance()
    {
        if (Mathf.Abs(transform.position.x - previousFrameX) > distanceBeforeRotation)
            return true;
        return false;
    }
}
