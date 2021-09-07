using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSocersMusicBg;
    public AudioClip[] musicBg;

    void Start()
    {
        RandomMusic();
    }

    private void RandomMusic()
    {
        int indexMusic = Random.Range(0, musicBg.Length);
        AudioClip currentMusic = musicBg[indexMusic];
        audioSocersMusicBg.clip = currentMusic;

        if (indexMusic == 0)
        {
            audioSocersMusicBg.volume = 0.2f;
            audioSocersMusicBg.Play();
        }else if (indexMusic == 1)
        {
            audioSocersMusicBg.volume = 0.4f;
            audioSocersMusicBg.Play();
        }
    }
}
