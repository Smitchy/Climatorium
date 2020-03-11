using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private PuzzleManager puzzMan;
    // Start is called before the first frame update
    void Awake()
    {
        puzzMan = GameObject.FindObjectOfType<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            puzzMan.NextPuzzle();
        }
    }
}
