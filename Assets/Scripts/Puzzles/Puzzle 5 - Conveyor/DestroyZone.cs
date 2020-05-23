using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    [SerializeField]
    private string tagToDestroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToDestroy))
            GameObject.Destroy(other.gameObject);
    }
}
