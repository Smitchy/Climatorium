using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private GameObject grabbedBy;
    private Vector3 previousFramePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            Vector3 updatedX = new Vector3(previousFramePosition.x - position.x , position.y, previousFramePosition.z);
            gameObject.transform.position = updatedX;
        }
        if(position.z != previousFramePosition.z)
        {
            Vector3 updatedZ = new Vector3(position.x, position.y, previousFramePosition.z - position.z);
            gameObject.transform.position = updatedZ;
        }
        previousFramePosition = position;
    }
}
