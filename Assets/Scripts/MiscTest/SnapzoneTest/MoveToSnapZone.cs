using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveToSnapZone : MonoBehaviour
{
    private bool grabbed, insideTrigger;
    public TMP_Text test;
    [SerializeField]
    private GameObject snapZoneTrigger;
    // Start is called before the first frame update
    void Start()
    {
        Snap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Snap();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "SnapZoneTrigger" || other.name == "ThingaMabob")
        {
            snapZoneTrigger = other.gameObject;
            insideTrigger = true;
            test.text = "inside snapzone, true";
        }
        else
        {
            insideTrigger = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        test.text = other.gameObject.name;
        if (other.name == "SnapZoneTrigger")
        {
            snapZoneTrigger = other.gameObject;
            insideTrigger = false;
            test.text = "inside snapzone, false";
        }
       
    }
    public void Snap()
    {
        if (!grabbed)
        {
            StartCoroutine(KeepInPlace());
            
            //snapZoneTrigger.transform.position = ;

        }
    }

    //set the grabbed boolean to opposite on method call
    public void ChangeState()
    {
        grabbed = !grabbed;
        test.text = grabbed + "";
    }

   public IEnumerator KeepInPlace()
    {
        while (true)
        {
            transform.position = snapZoneTrigger.transform.position;
            yield return new WaitForSeconds(0.01f);
        }
        
    }
}
