using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK.Prefabs.Interactions.Interactors;
using TMPro;

/// <summary>
/// Contains all methods for the wrench puzzle, extends iPuzzle
/// </summary>
/// <remarks>
/// Class can setup the puzzle, tear it down, reset the puzzle object and check for trigger collisions relating to the puzzle
/// </remarks>
public class WrenchPuzzle : MonoBehaviour
{

    private UnityEvent ResetWrenchEvent;
    [HideInInspector]
    public Vector3 startPos { get; set; }
    private bool triggeredStart, won;
    public GameObject startGo, endGo, wrenchShaft;
    public Material green, red, blue;
    public InteractorFacade interactorScriptLeft, interactorScriptRight;
    public Timer time;

    public TMP_Text test1, test2;

    private void Start()
    {
        if (ResetWrenchEvent == null)
        {
            ResetWrenchEvent = new UnityEvent();
        }
        ResetWrenchEvent.AddListener(ResetWrench);

        ResetWrenchEvent.AddListener(LetGoOfStuff);

        startPos = transform.position;
    }
   

    /// <summary>
    /// reset the position of the wrench to start position using startposition set in setup
    /// </summary>
    void ResetWrench()
    {
        wrenchShaft.transform.position = startPos;
        triggeredStart = false;
        startGo.GetComponent<Renderer>().material = red;

    }

    /// <summary>
    /// trigger to see if the player moved the wrench outside of the bounds
    /// </summary>
    /// <param name="other">should always be the track of the puzzle</param>
    private void OnTriggerExit(Collider other)
    {
        test1.text = "";
        test2.text = "exited " + other.name;
        //if(other.name == "Interactable.Primary_Grab.Secondary_Swap")
        if (!won && other.tag == "Track")
        {
            TriggerEvent();
            time.stopTimer.Invoke();

        }
    }

    /// <summary>
    /// Trigger to start the puzzle setting triggeredStart boolean to true 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        test2.text = "";
        test1.text = "triggered by " + other.name;
        test2.text = other.tag + " this is the tag";
        if (!triggeredStart && other.name == startGo.name)
        {
            triggeredStart = true;
            startGo.GetComponent<Renderer>().material = green;
        }
        //start timer if start has been triggered and colliding with the course
        if (triggeredStart && other.tag == "Track")
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
    /// <summary>
    ///private method that uses VRTK to let go of what ever is in the users hand
    /// </summary>
    void LetGoOfStuff()
    {
        interactorScriptLeft.Ungrab();
        interactorScriptRight.Ungrab();
    }
    /// <summary>
    /// public method to trigger reset puzzle event
    /// </summary>
    public void TriggerEvent()
    {
        ResetWrenchEvent.Invoke();
    }
}