using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;


public class SoundPoolMan : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> pooledAudioSourceContainers;

 
    //get index of an object from the pool
    private int TakeFromObjectPool()
    {
        
        for(int i = 0; i < pooledAudioSourceContainers.Count; i++)
        {
            if (!pooledAudioSourceContainers[i].activeSelf)
            {
                return i;
            }
        }
        return -1;
        
    }
    //start the coroutine with a sound and a destination. Maybe add a boolean to decide if the sound should be looped could be called from and event
    public void SetupSoundPlayer(AudioClip sound, Transform destination)
    {
        StartCoroutine(SoundPLayer(sound, destination));
        //pooledPlayer.SetActive(true);
    }

    //sets up the player then plays given sound at a given location - set inactive/return to pool after clip length plus a millisecond 
    private IEnumerator SoundPLayer(AudioClip clip, Transform destination)
    {
        int index = TakeFromObjectPool();
        
        pooledAudioSourceContainers[index].SetActive(true);
        pooledAudioSourceContainers[index].transform.position = destination.position;
        pooledAudioSourceContainers[index].GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length+ 0.01f);
        
        pooledAudioSourceContainers[index].SetActive(false);
    }

    //testing
    //private IEnumerator playmore()
    //{
    //    //foreach (GameObject location in locations)
    //    for(int i =0; i < pooledAudioSourceContainers.Count; i++)
    //    {

    //        SetupSoundPlayer(clip, pooledAudioSourceContainers[i].transform);

    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}
}
