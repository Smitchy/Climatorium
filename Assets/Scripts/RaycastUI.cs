using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastUI : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray,out hit, 3000f, layer))
        {
            Debug.Log("HIT: " + hit.collider.gameObject.name);
        }
    }
}
