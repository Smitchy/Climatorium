using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


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
    private bool running;

    public TMP_Text scoreTxt;
    
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

        animationSpeed = 0.01f;;
        scores = new List<int>();
    }

    private void Update()
    {

        //for testing
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     ScoreEvent.Invoke(points);
        // }
        scoreTxt.text = _score + " ";
    }

    /// <summary>
    /// public available method to add/subtract points over time
    /// </summary>
    /// <param name="point"></param>
    public void ManageScore(int point)
    {
        if(!running)
        {
            running = true;
            increaseScore = StartCoroutine(IncreaseOverX(point));
        }
    }
    /// <summary>
    /// gets the current score
    /// </summary>
    /// <returns>the current score</returns>
    public int GetScore()
    {
        return _score;
    }
    /// <summary>
    /// return highscores
    /// </summary>
    /// <returns></returns>
    public List<int> GetScores()
    {
        return scores;
    }

    
    /// <summary>
    ///adds the current score to the overall scores then resets current score
    /// </summary>
    public void ResetScore()
    {
        scores.Add(_score);
        _score = 0;
    }
    //
    /// <summary>
    /// Resets all the scores - highscore wip
    /// needs to hook up to persistence
    /// </summary>
    public void ResetScores()
    {
        scores = new List<int>();
    }

    /// <summary>
    /// should add the current score to the player prefs
    /// </summary>
    public void SaveScore()
    {
        //save score in playerprefs when said is made
    }
    //
    /// <summary>
    /// coroutine to handle adding or subracting score over time by 
    /// </summary>
    /// <param name="x">in-/decrease x score</param>
    /// <returns></returns>
    private IEnumerator IncreaseOverX(int x)
    {
        
        if (x > 0)
        {
            for (int i = 0; i < x; i++)
            {
                _score++;
                print(_score);
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
        running = false;
    }

    
}
