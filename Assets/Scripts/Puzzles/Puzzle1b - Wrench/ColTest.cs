using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColTest : MonoBehaviour
{

    public PuzzleManager puzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(NextPuzzle());
    }
    private IEnumerator NextPuzzle()
    {
        yield return new WaitForSeconds(2.5f);
        puzzleManager.NextPuzzle();
    }

}
