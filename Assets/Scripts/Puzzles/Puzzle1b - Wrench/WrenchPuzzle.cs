﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK.Prefabs.Interactions.Interactors;
using TMPro;

public class WrenchPuzzle : iPuzzle
{

    private UnityEvent ResetWrenchEvent;
    [HideInInspector]
    public Vector3 startPos { get; set; }
    private Collider start,end;
    private bool triggeredStart, won;
    public GameObject startGo, endGo, wrenchShaft;
    public Material green,red,blue;
    public InteractorFacade interactorScriptLeft, interactorScriptRight;
    public Timer time;

    public TMP_Text testTxt;
    


    //Example of overriden attributes (abstract, NOT optional)
    public override float example
    {
        get
        {
            return 0;
        }
    }
    //Example of overriden attributes (virtual, optional
    public override float exampleTwo
    {
        get
        {
            return 0;
        }
        set
        {

        }
    }

    private void Start() 
    {
        SetUp();   
    }

    public override void SetUp()
    {
         if(ResetWrenchEvent == null)
        {
            ResetWrenchEvent = new UnityEvent();
        }
        ResetWrenchEvent.AddListener(ResetWrench);
        ResetWrenchEvent.AddListener(HapticFeedBack);
        ResetWrenchEvent.AddListener(LetGoOfStuff);

        startPos = transform.position;
    }

    public override void TearDown()
    {
        //remove game defining collders - start/end and obstacle course
        throw new System.NotImplementedException("no teardown defined");
    }

    void Update()
    {
        //for testing
        // if(Input.GetKeyDown(KeyCode.B))
        // {
           
        //     for(int i = 0 ; i < 40; i++)
        //     {
        //         transform.Translate(Vector3.left * Time.deltaTime);

        //     }
        // }
    }

    //reset the position of the wrench
    void ResetWrench()
    {
        wrenchShaft.transform.position = startPos;
        triggeredStart = false;
        startGo.GetComponent<Renderer>().material = red;

    }

    //Vibrate the controller when failed - should probably be somewhere else
    void HapticFeedBack()
    {

    }

    //trigger to see if the player moved the wrench outside of the bounds
    private void OnTriggerExit(Collider other) 
    {
        //if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
        if (!won && other.name == "Rail")
        {
            print("test");
            TriggerEvent();
            time.stopTimer.Invoke();
            // timer.stopTimer.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if (!triggeredStart && other.name == startGo.name)
        {
            triggeredStart = true;
            startGo.GetComponent<Renderer>().material = green;
        }
        //start timer if start has been triggered and colliding with the course
        if(triggeredStart && other.name == "Rail")
        {
            time.startTimer.Invoke();
            //testTxt.text = "should startTime";
        }
        if (other.name == endGo.name)
        {
            won = true;
            time.win.Invoke();
           
        }
    }

    void LetGoOfStuff()
    {
        interactorScriptLeft.Ungrab();
        interactorScriptRight.Ungrab();
    }

    public void TriggerEvent()
    {
        ResetWrenchEvent.Invoke();
    }
    // private Vector3 startPos;

    // private UnityEvent ResetWrenchEvent;
    // Start is called before the first frame update
    // void Start()
    // {
    //     if(ResetWrenchEvent == null)
    //     {
    //         ResetWrenchEvent = new UnityEvent();
    //     }
    //     ResetWrenchEvent.AddListener(ResetWrench);
    //     ResetWrenchEvent.AddListener(HapticFeedBack);

    //     startPos = transform.position;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.B))
    //     {
           
    //         for(int i = 0 ; i < 40; i++)
    //         {
    //             transform.Translate(Vector3.left * Time.deltaTime);

    //         }
    //     }
    // }

    // //reset the position of the wrench
    // void ResetWrench()
    // {
    //     transform.position = startPos;
    // }

    // //Vibrate the controller when failed - should probably be somewhere else
    // void HapticFeedBack()
    // {

    // }

    // private void OnTriggerExit(Collider other) 
    // {
    //     if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
    //     {
    //         print("test");
    //         TriggerEvent();
    //     }
    // }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
    //     {
    //         print("enter");
    //     }
    // }

    // public void TriggerEvent()
    // {
    //     ResetWrenchEvent.Invoke();
    // }
}


/*public class WrenchPuzzle1 : iPuzzle
{
    
}*/
