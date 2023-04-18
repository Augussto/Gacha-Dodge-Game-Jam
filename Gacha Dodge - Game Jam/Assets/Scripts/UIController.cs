using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text textPoins;
    public GameObject backToMenuBtn;
    public GameObject[] lifes;

    public GameObject orangeBg, yellowBg;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textPoins.text = gm.currentPoints.ToString();
    }

    public void DefeatScreen()
    {
        backToMenuBtn.SetActive(true);
        gm.isPlaying = false;
    }

    public void BackToMenu()
    {
        gm.isPlaying = true;
        Debug.Log("Time Scale: " + Time.timeScale);
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeBg(bool x)
    {
        orangeBg.SetActive(!x);
        yellowBg.SetActive(x);
    }
}
