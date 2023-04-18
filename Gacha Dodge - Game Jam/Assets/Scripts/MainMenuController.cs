using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public MusicController mc;
    public GameObject musicButton;

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
            musicButton.GetComponentInChildren<Text>().text = "MUSIC ON";
        }
        else
        {
            musicButton.GetComponentInChildren<Text>().text = "MUSIC OFF";
        }
    }
    public void UpdateVolume()
    {
        if (mc.activateMusic)
        {
            mc.activateMusic = false;
            musicButton.GetComponentInChildren<Text>().text = "MUSIC OFF";
        }
        else
        {
            mc.activateMusic = true;
            musicButton.GetComponentInChildren<Text>().text = "MUSIC ON";
        }
    }

}
