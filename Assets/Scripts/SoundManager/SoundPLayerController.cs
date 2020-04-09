using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SoundEvent : UnityEvent<GameObject>
{
}

public class SoundPLayerController : MonoBehaviour
{

    public SoundEvent playSoundAtLocatoin;
    // Start is called before the first frame update
    void Start()
    {
        if(playSoundAtLocatoin == null)
        {
            playSoundAtLocatoin = new SoundEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlaySound(GameObject go)
    {

    }
}
