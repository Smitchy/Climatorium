using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            collision.gameObject.transform.Translate(speed * transform.forward, Space.World);
        }
    }
}
