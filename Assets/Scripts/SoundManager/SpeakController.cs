using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StartedPuzzle : UnityEvent<List<AudioClip>, List<AudioClip>, List<AudioClip>>
{
}
public class SpeakController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> speakQueue, _hints, _sarcasm;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float timeBetweenSpeak;
    [SerializeField]
    private AudioClip finalHint;
    private Coroutine _Speak;
    private float timeSinceEnable;
    private bool inactive;
    public StartedPuzzle startedPuzzle;

    public SoundPoolMan soundPool;
    private bool running;

    private void Start()
    {
        if(startedPuzzle == null)
        {
            startedPuzzle = new StartedPuzzle();
        }
        startedPuzzle.AddListener(AddPuzzleRelatedSounds);
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
            soundPool.SetupSoundPlayer(clip, player.gameObject, true);
            speakQueue.Remove(clip);
            yield return new WaitForSeconds(clip.length + timeBetweenSpeak);
            _Speak = StartCoroutine(SpeakRoutine());
        }

    }

    
    /// <summary>
    /// sets the speaklists from event that should be fired at all puzzle start
    /// </summary>
    /// <param name="hintsTips"></param>
    /// <param name="tips"></param>
    /// <param name="sarcasm"></param>
    private void AddPuzzleRelatedSounds(List<AudioClip> hintsTips, List<AudioClip> tips, List<AudioClip> sarcasm)
    {
        _hints = hintsTips;
        _sarcasm = sarcasm;
        timeSinceEnable = Time.time;
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
