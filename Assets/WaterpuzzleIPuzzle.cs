using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterpuzzleIPuzzle : iPuzzle
{
    public GameObject ground;
    public PipeManager pipeMan;
    private IEnumerator Narrator;
    public SoundPoolMan soundPoolMan;
    public Transform soundFollowLocation;
    public List<AudioClip> sounds;

    public override void SetUp()
    {
        gameObject.SetActive(true);
        GroundCollisionHandler GCH = ground.AddComponent<GroundCollisionHandler>();
        GCH.pipeManager = pipeMan;
        Narrator = NarratorSoundIntro();
        StartCoroutine(Narrator);
        
    }

    public override void TearDown()
    {
        gameObject.SetActive(false);
        Destroy(ground.GetComponent<GroundCollisionHandler>());
    }
    private IEnumerator NarratorSoundIntro()
    {
        yield return new WaitForSeconds(5.0f);
        soundPoolMan.SetupSoundPlayer(sounds[0], soundFollowLocation.gameObject, false);
        yield return new WaitForSeconds(13.0f);
        soundPoolMan.SetupSoundPlayer(sounds[1], soundFollowLocation.gameObject, false);
        yield return new WaitForSeconds(10.0f);
        soundPoolMan.SetupSoundPlayer(sounds[2], soundFollowLocation.gameObject, false);

    }
}
