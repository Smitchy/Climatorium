using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private List<iPuzzle> puzzles;
    public iPuzzle currentPuzzle { get; private set; }


    private void Awake()
    {
        currentPuzzle = null;
    }

    public void NextPuzzle()
    {
        int p = puzzles.IndexOf(currentPuzzle);
        if (currentPuzzle != null)
        {
            if(p < puzzles.Capacity-1)
            {
                currentPuzzle.TearDown();
                currentPuzzle = puzzles[p + 1];
                currentPuzzle.SetUp();
            }
            else
            {
                currentPuzzle.TearDown();
                currentPuzzle = null;
                Debug.Log("Last puzzle completed.");
            }
        }
        else
        {
            if(puzzles.Capacity > 0)
            {
                currentPuzzle = puzzles[0];
                currentPuzzle.SetUp();
            }
        }
    }

    public void NextPuzzle(iPuzzle puzzle)
    {
        if(currentPuzzle != null)
        {
            currentPuzzle.TearDown();
        }
        currentPuzzle = puzzle;
        currentPuzzle.SetUp();
    }

}
