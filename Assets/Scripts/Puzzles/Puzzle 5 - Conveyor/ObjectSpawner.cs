using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public bool spawning;

    [SerializeField]
    private List<GameObject> spawnables;
    [SerializeField]
    private float speed;

    private Coroutine spawnRoutine;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (spawning)
        {
            SpawnRandom();
            yield return new WaitForSeconds(speed);
        }
    }


    private void SpawnRandom()
    {
        //select random object to spawn
        int selected = Random.Range(0, spawnables.Count - 1);

        GameObject.Instantiate(spawnables[selected], transform.position, Quaternion.identity, transform);
    }


}
