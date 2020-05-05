using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;


public class SoundPoolMan : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> pooledAudioSourceContainers;
    [SerializeField]
    private List<GameObject> testLocations;
    [SerializeField]
    private GameObject audioSourcePrefab;

    public AudioClip clip;
    bool started;

   
    private void Update()
    {
        if (Time.time > 0.5f && !started)
        {
            started = true;
            StartCoroutine(playmore());
        }
        
    }

    
    /// <summary>
    /// get index of an object from the pool
    /// </summary>
    /// <returns></returns>
    private int TakeFromObjectPool()
    {

        for (int i = 0; i < pooledAudioSourceContainers.Count; i++)
        {
            if (!pooledAudioSourceContainers[i].activeSelf)
            {
                return i;
            }
            //else
            //{
            //    pooledAudioSourceContainers.Add(audioSourcePrefab);
            //}
        }
        return -1;

    }

    
    /// <summary>
    /// start the coroutine with a sound and a destination. Maybe add a boolean to decide if the sound should be looped could be called from and event
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="destination"></param>
    public void SetupSoundPlayer(AudioClip sound, Transform destination)
    {
        StartCoroutine(SoundPLayer(sound, destination));
        //pooledPlayer.SetActive(true);
    }

    /// <summary>
    /// 
    //sets up the player then plays given sound at a given location - set inactive/return to pool after clip length plus a millisecond
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    private IEnumerator SoundPLayer(AudioClip clip, Transform destination)
    {
        int index = TakeFromObjectPool();

        pooledAudioSourceContainers[index].SetActive(true);
        pooledAudioSourceContainers[index].transform.position = destination.position;
        pooledAudioSourceContainers[index].GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length + 0.01f);

        pooledAudioSourceContainers[index].SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator playmore()
    {

        //foreach (GameObject location in locations)
        for (int i = 0; i < testLocations.Count; i++)
        {
            
            SetupSoundPlayer(clip, testLocations[i].transform);

            yield return new WaitForSeconds(1);
        }
    }
}



