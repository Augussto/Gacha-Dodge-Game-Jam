using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text textPoins;
    public GameObject backToMenuBtn;
    public GameObject[] lifes;

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
        Time.timeScale = 0;
    }

    public void BackToMenu()
    {

    }
}
