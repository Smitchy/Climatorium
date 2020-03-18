using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetupWrench : MonoBehaviour
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

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //reset the position of the wrench
    void ResetWrench()
    {
        transform.position = startPos;
    }

    //Vibrate the controller when failed
    void HapticFeedBack()
    {

    }




}
