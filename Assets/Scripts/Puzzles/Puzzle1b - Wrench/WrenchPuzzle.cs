using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK.Prefabs.Interactions.Interactors;


public class WrenchPuzzle : iPuzzle
{

    private UnityEvent ResetWrenchEvent;
    [HideInInspector]
    public Vector3 startPos { get; set; }
    private bool triggeredStart, won;
    public GameObject startGo, endGo, wrenchShaft;
    public Material green, red, blue;
    public InteractorFacade interactorScriptLeft, interactorScriptRight;
    public Timer time;

    private void Start()
    {
        SetUp();
    }

    public override void SetUp()
    {
        if (ResetWrenchEvent == null)
        {
            ResetWrenchEvent = new UnityEvent();
        }
        ResetWrenchEvent.AddListener(ResetWrench);

        ResetWrenchEvent.AddListener(LetGoOfStuff);

        startPos = transform.position;
    }

    public override void TearDown()
    {
        //remove game defining collders - start/end and obstacle course
        throw new System.NotImplementedException("no teardown defined");
    }



    //reset the position of the wrench
    void ResetWrench()
    {
        wrenchShaft.transform.position = startPos;
        triggeredStart = false;
        startGo.GetComponent<Renderer>().material = red;


    }


    //trigger to see if the player moved the wrench outside of the bounds
    private void OnTriggerExit(Collider other)
    {
        //if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
        if (!won && other.name == "Rail")
        {
            TriggerEvent();
            time.stopTimer.Invoke();

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
        if (triggeredStart && other.name == "Rail")
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
}