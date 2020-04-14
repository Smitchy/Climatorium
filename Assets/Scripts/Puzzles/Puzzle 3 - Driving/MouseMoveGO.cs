using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveGO : MonoBehaviour
{
    private Vector3 previousFrameMousePos;
    private bool shouldMove;
    [SerializeField]
    private Camera mainCamera;
    private RaycastHit hit;
    [SerializeField]
    private string hitTag;
    [SerializeField]
    private float speedScale;
    [SerializeField]
    private CarMovement carMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MouseOverCar())
        {
            shouldMove = true;
            carMovement.Grabbed(gameObject);
            previousFrameMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            carMovement.Released();
            shouldMove = false;
        }
        if (shouldMove)
        {
            ProcessMovement();
        }
    }
    private bool MouseOverCar()
    {
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.tag == "Car")
            {
                return true;
            }
        }
        return false;
    }
    private void ProcessMovement()
    {
        Vector3 currentFrameMousePos = Input.mousePosition;
        if(currentFrameMousePos != previousFrameMousePos)
        {
            if(currentFrameMousePos.x != previousFrameMousePos.x)
            {
                MoveX((currentFrameMousePos.x - previousFrameMousePos.x)*speedScale);
            }
            if (currentFrameMousePos.y != previousFrameMousePos.y)
            {
                MoveZ((currentFrameMousePos.y - previousFrameMousePos.y)*speedScale);
            }
            previousFrameMousePos = currentFrameMousePos;
        }
    }
    private void MoveX(float x)
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.x -= x;
        gameObject.transform.position = newPosition;
    }
    private void MoveZ(float z)
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.z -= z;
        gameObject.transform.position = newPosition;
    }
}
