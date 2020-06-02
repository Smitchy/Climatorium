using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSoundManager : MonoBehaviour
{
    public SoundPoolMan soundPoolMan;
    public GameObject soundLocation;
    public List<AudioClip> sounds;
    public PuzzleManager puzzleManager;

    public void PlaySound(int soundRef)
    {
        if (soundRef != 2)
        {
            soundPoolMan.SetupSoundPlayer(sounds[soundRef], soundLocation, false);
        }
        else
        {
            StartCoroutine(Sounds());
        }
    }
    private IEnumerator Sounds()
    {
        yield return new WaitForSeconds(1.0f);
        soundPoolMan.SetupSoundPlayer(sounds[2], soundLocation, false);
        yield return new WaitForSeconds(6.0f);
        soundPoolMan.SetupSoundPlayer(sounds[3], soundLocation, false);
        yield return new WaitForSeconds(6.0f);
        puzzleManager.NextPuzzle();
    }
}
