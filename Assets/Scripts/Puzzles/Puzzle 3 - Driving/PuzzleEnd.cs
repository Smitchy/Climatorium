using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnd : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    private void OnTriggerEnter(Collider col)
    {
        StartCoroutine(EndPuzzle());
    }
    private IEnumerator EndPuzzle()
    {
        yield return new WaitForSeconds(2.0f);
        puzzleManager.NextPuzzle();
    }
}
