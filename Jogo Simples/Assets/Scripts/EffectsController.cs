using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public AudioSource coinEffect;
    
    void Update()
    {
        if (MovePlayer.wasCollected)
        {
            coinEffect.volume = 0.3f;
            coinEffect.Play();
            MovePlayer.wasCollected = false;
        }
    }
}
