using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSocersMusicBg;
    public AudioClip[] musicBg;
    GameObject bgm;

    void Start()
    {
        RandomMusic();
        Destroy(GameObject.Find("BGM"));
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
