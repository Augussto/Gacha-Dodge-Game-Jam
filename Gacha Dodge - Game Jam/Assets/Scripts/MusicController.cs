using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public bool activateMusic;
    private static GameObject instance;

    public AudioSource song;
    private AudioSource[] listsongs;
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
            int x = 0;
            while (song == null)
            {
                listsongs = FindObjectsOfType<AudioSource>();
                if(listsongs[x].tag == "Song")
                {
                    song = listsongs[x];
                }
                else
                {
                    x++;
                }
            }
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
