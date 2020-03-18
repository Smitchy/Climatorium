using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name + " entered: " + gameObject.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.collider.name + " exited: " + gameObject.name);
    }
}
