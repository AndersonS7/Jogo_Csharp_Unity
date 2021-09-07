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
        audioSocersMusicBg.volume = 0.3f;
        audioSocersMusicBg.Play();
    }
}
