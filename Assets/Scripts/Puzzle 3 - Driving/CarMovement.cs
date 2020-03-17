using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private GameObject grabbedBy;
    private Vector3 previousFramePosition;

    void Update()
    {
        if(grabbedBy != null)
        {
            ProcessMovement(grabbedBy.transform.position);
        }
    }

    public void Grabbed(GameObject go)
    {
        grabbedBy = go;
    }
    public void Released()
    {
        grabbedBy = null;
    }
    //TODO checks for movement relating to maze.
    //Potential grid based movement
    //Resets if hitting "water"
    public void ProcessMovement(Vector3 position)
    {
        if(position.x != previousFramePosition.x)
        {
            if(previousFramePosition.x > position.x)
            {
                if (CheckHorizontalMovement(true))
                {
                    Debug.Log("Positive Horizontal");
                    Vector3 updatedX = new Vector3(gameObject.transform.position.x - (previousFramePosition.x - position.x), gameObject.transform.position.y, gameObject.transform.position.z);
                    gameObject.transform.position = updatedX;
                }
            }
            else
            {
                if (CheckHorizontalMovement(false))
                {
                    Debug.Log("Negative Horizontal");
                    Vector3 updatedX = new Vector3(gameObject.transform.position.x - (previousFramePosition.x - position.x), gameObject.transform.position.y, gameObject.transform.position.z);
                    gameObject.transform.position = updatedX;
                }
            }
        }
        if(position.z != previousFramePosition.z)
        {
            if(previousFramePosition.z > position.z)
            {
                if (CheckVerticalMovement(true))
                {
                    Debug.Log("Positive Vertical");
                    Vector3 updatedZ = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (previousFramePosition.z - position.z));
                    gameObject.transform.position = updatedZ;
                }
            }
            else
            {
                if (CheckVerticalMovement(false))
                {
                    Debug.Log("Negative Vertical");
                    Vector3 updatedZ = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (previousFramePosition.x - position.z));
                    gameObject.transform.position = updatedZ;
                }
            }
        }
        previousFramePosition = position;
    }
    private bool CheckHorizontalMovement(bool forward)
    {
        Vector3 direction = forward ? gameObject.transform.forward : -gameObject.transform.forward;
        RaycastHit hit;
        if(Physics.Raycast(new Ray(gameObject.transform.position, direction), out hit, 0.55f))
        {
            if(hit.collider.tag == "Maze")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckVerticalMovement(bool up)
    {
        Vector3 direction = up ? -gameObject.transform.right : gameObject.transform.right;
        RaycastHit hit;
        if (Physics.Raycast(new Ray(gameObject.transform.position, direction), out hit, 0.45f))
        {
            if (hit.collider.tag == "Maze")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }
}
