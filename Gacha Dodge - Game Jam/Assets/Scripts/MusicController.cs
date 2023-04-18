using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public bool activateMusic;
    private static GameObject instance;

    public AudioSource song;
    private bool isAlreadyPlaying;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        activateMusic = true;
        
        if (instance == null) 
        { 
            instance = gameObject;
        }
        else 
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if(song == null)
        {
            song = FindAnyObjectByType<AudioSource>();
            if (activateMusic)
            {
                song.Play();
                isAlreadyPlaying = true;
            }
        }
        
        if(activateMusic && !isAlreadyPlaying)
        {
            song.Play();
            isAlreadyPlaying = true;
        }
        else if(!activateMusic && isAlreadyPlaying)
        {
            song.Stop();
            isAlreadyPlaying = false;
        }
    }


}
