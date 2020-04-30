using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float zOffset = 1f;
    public GameObject headAnchor;
    public bool shouldFollow;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = headAnchor.transform.position + headAnchor.transform.forward * zOffset;
        transform.rotation = headAnchor.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (shouldFollow)
        {
            transform.position = headAnchor.transform.position + headAnchor.transform.forward * zOffset;
            transform.rotation = headAnchor.transform.rotation;
        }*/
        if (once)
        {
            transform.position = headAnchor.transform.position + headAnchor.transform.forward * zOffset;
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            once = false;
        }
    }
}
