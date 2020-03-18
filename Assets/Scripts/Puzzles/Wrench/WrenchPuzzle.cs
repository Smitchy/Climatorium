using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WrenchPuzzle : MonoBehaviour
{

    private Vector3 startPos;

    private UnityEvent ResetWrenchEvent;
    // Start is called before the first frame update
    void Start()
    {
        if(ResetWrenchEvent == null)
        {
            ResetWrenchEvent = new UnityEvent();
        }
        ResetWrenchEvent.AddListener(ResetWrench);
        ResetWrenchEvent.AddListener(HapticFeedBack);

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
           
            for(int i = 0 ; i < 40; i++)
            {
                transform.Translate(Vector3.left * Time.deltaTime);

            }
        }
    }

    //reset the position of the wrench
    void ResetWrench()
    {
        transform.position = startPos;
    }

    //Vibrate the controller when failed - should probably be somewhere else
    void HapticFeedBack()
    {

    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
        {
            print("test");
            TriggerEvent();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
        {
            print("enter");
        }
    }

    public void TriggerEvent()
    {
        ResetWrenchEvent.Invoke();
    }
}
