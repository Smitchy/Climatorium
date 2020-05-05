using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeakController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> speakQueue;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float timeBetweenSpeak;
    [SerializeField]
    private AudioClip finalHint;
    private Coroutine _Speak;
    private float timeSinceEnable;
    private bool inactive;
    public UnityEvent inactivity;

    public SoundPoolMan soundPool;
    private bool running;

    private void Start()
    {
        if(inactivity == null)
        {
            inactivity = new UnityEvent();
        }

    }
    private void OnEnable()
    {
        timeSinceEnable = Time.time;
    }
    public void AddToQueue(AudioClip clip)
    {
        speakQueue.Add(clip);
        if (!running)
        {
            running = !running;
            _Speak = StartCoroutine(SpeakRoutine());
        }
    }
    /// <summary>
    /// Coroutine that will repeat itself until there are no more 
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpeakRoutine()
    {
        if(speakQueue.Count == 0)
        {
            print("stopped " + speakQueue.Count);
            running = !running;//should be changed to false at this point
            yield return null;
        }
        
        else
        {
            AudioClip clip = speakQueue[0];
            soundPool.SetupSoundPlayer(clip, player);
            speakQueue.Remove(clip);
            yield return new WaitForSeconds(clip.length + timeBetweenSpeak);
            _Speak = StartCoroutine(SpeakRoutine());
        }

    }

    /// <summary>
    /// Method to determine if the player needs a hint
    /// </summary>
    private bool NeedAHint()
    {
        float delta = Time.time - timeSinceEnable;
        int deltaInt = Mathf.FloorToInt(delta);
        bool playSpeak = false;
        //if (deltaInt % )
        //{

        //}

        return playSpeak;
    }


}
