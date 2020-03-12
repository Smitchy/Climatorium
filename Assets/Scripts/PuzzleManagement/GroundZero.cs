using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundZero : MonoBehaviour
{
    private int infectNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginOutbreak());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator BeginOutbreak()
    {
        GameObject go = new GameObject("InfectedChinaman" + infectNumber);
        infectNumber++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(BeginOutbreak());
        StartCoroutine(BeginOutbreak());
    }
}
