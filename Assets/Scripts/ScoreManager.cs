using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}
public class ScoreManager : MonoBehaviour
{
    public IntEvent ScoreEvent;
    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        //invoke event with an integer as input. 
        if(ScoreEvent == null)
        {
            ScoreEvent = new IntEvent();
        }
        ScoreEvent.AddListener(ManageScore);
    }

   void ManageScore(int point)
    {
        _score += point;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SaveScore()
    {
        //save score in playerprefs when said is made
    }
}
