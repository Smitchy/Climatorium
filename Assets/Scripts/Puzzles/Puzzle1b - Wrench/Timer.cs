using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public ScoreManager score;
    private UnityEvent startTimer, stopTimer;
    private bool running;
    private Coroutine _TimeRoutine;
    private int timePassed;
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
        stopTimer.AddListener(GenerateScore);
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
            yield return new WaitForSeconds(1);
            print(timePassed + " time");
        }
    }

    void GenerateScore()
    {  
        StopCoroutine(_TimeRoutine);
        running = !running;
        score.ManageScore(timePassed);

    }
}
