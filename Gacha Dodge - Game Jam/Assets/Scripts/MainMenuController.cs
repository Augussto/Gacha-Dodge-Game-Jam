using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public MusicController mc;
    public GameObject musicButtonOn;
    public GameObject musicButtonOff;

    private void Start()
    {
        mc = FindObjectOfType<MusicController>();
        CheckSound();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    private void CheckSound()
    {
        if (mc.activateMusic)
        {
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
        else
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
    }
    public void UpdateVolume()
    {
        if (mc.activateMusic)
        {
            mc.activateMusic = false;
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
        else
        {
            mc.activateMusic = true;
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
    }

}
