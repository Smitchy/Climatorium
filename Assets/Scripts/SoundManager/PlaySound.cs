using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class PlaySound : MonoBehaviour
{

    private bool playing;
    private AudioSource soundSrc, newPlayer;
    public Coroutine SoundRoutine;

    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private List<AudioClip> sounds;
    [SerializeField]
    private Vector3 soundPosition;

    

    // Start is called before the first frame update
    void Start()
    {
        soundSrc = gameObject.AddComponent<AudioSource>();
        StartPlayer(transform.position,clip);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPlayer(Vector3 soundPositionIn3DSpace, AudioClip sound)
    {
        if (!playing)
        {
            playing = !playing;
            SoundRoutine = StartCoroutine(Player(soundPositionIn3DSpace,sound));
        }
    }

    private IEnumerator Player(Vector3 position, AudioClip sound)
    {
        
        transform.position = position;
        soundSrc.PlayOneShot(sound);
        print("hey before");
        yield return new WaitForSeconds(sound.length + 0.02f);
        print("hey after");
        
        playing = !playing;
    }
}
