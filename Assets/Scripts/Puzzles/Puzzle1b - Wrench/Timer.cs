using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public ScoreManager score;
    [HideInInspector]
    public UnityEvent startTimer, stopTimer, win;
    private bool running;
    private Coroutine _TimeRoutine;
    private int timePassed;
    public TMP_Text timerTxt;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 300;

        if(startTimer == null)
        {
            startTimer = new UnityEvent();
        }
        startTimer.AddListener(RunTimer);

        if(stopTimer == null)
        {
            stopTimer = new UnityEvent();
        }
        stopTimer.AddListener(FailedAttempt);
        if(win == null)
        {
            win = new UnityEvent();
        }
        win.AddListener(GenerateScore);
        timerTxt.text = timePassed + "";
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            startTimer.Invoke();
        }
        if(Input.GetKey(KeyCode.B))
        {
            stopTimer.Invoke();
        }
    }
    //start coroutine
    void RunTimer()
    {
        if(!running)
        {
            running = !running;
            _TimeRoutine = StartCoroutine(TimeRoutine());
        }

    }

    //count up or down 
    private IEnumerator TimeRoutine()
    {
        while(true)
        {
            timePassed--;
            timerTxt.text = timePassed + "";
            yield return new WaitForSeconds(1);
            print(timePassed + " time");
        }
    }
    
    void FailedAttempt()
    {
        StopTime();
        running = !running;
    }

    void GenerateScore()
    {
        StopTime();
        running = !running;
        score.ManageScore(timePassed);

    }

    void StopTime()
    {
        StopCoroutine(_TimeRoutine);
    }
}
