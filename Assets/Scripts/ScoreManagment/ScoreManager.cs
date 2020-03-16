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

    private IntEvent ScoreEvent;
    private int _score;
    public Coroutine increaseScore;
    private List<int> scores;
    [Tooltip("Unity doesn't have class tooltips")]
    public string howToTest = "Press space";
    //for testing
    [Tooltip("Amount of points, positive or negative - int")]
    public int points;
    [Tooltip("Speed between increase in points")]
    public float animationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        //invoke event with an integer as input. 
        if (ScoreEvent == null)
        {
            ScoreEvent = new IntEvent();
        }
        ScoreEvent.AddListener(ManageScore);

        animationSpeed = 1;
        scores = new List<int>();
    }

    private void Update()
    {

        //for testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreEvent.Invoke(points);
        }
    }


    private void ManageScore(int point)
    {
        increaseScore = StartCoroutine(IncreaseOverX(point));
    }

    public int GetScore()
    {
        return _score;
    }

    public List<int> GetScores()
    {
        return scores;
    }


    public void ResetScore()
    {
        scores.Add(_score);
        _score = 0;
    }
    public void ResetScores()
    {
        scores = new List<int>();
    }

    public void SaveScore()
    {
        //save score in playerprefs when said is made
    }
    //add or subract score over time 
    private IEnumerator IncreaseOverX(int x)
    {
        print(_score);
        if (x > 0)
        {
            for (int i = 0; i < x; i++)
            {
                _score++;
                yield return new WaitForSeconds(animationSpeed);
            }

        }
        else
        {
            for (int i = 0; i > x; i--)
            {
                _score--;
                yield return new WaitForSeconds(animationSpeed);
            }
        }
        print(_score + " score end");
    }

    
}
