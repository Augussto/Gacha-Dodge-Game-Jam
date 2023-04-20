using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPoints;
    public int spawnRate;
    public bool isPlaying;
    public bool powerUp;

    private float timer;

    private PlayerStatus ps;
    private UIController uic;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        isPlaying = true;
        powerUp = false;
        currentPoints = 0;
        spawnRate = 35;
        ps = FindObjectOfType<PlayerStatus>();
        uic = FindObjectOfType<UIController>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.currentLife == 0)
        {
            uic.DefeatScreen();
        }

        if (powerUp)
        {
            timer += Time.deltaTime * 1.5f;
            currentPoints = (int)timer;
        }
        else
        {
            timer += Time.deltaTime;
            currentPoints = (int)timer;
        }

        if(currentPoints == 20)
        {
            spawnRate = 30;
        }
        else if (currentPoints == 40)
        {
            spawnRate = 25;
        }
        else if(currentPoints == 80)
        {
            spawnRate = 20;
        }
        else if(currentPoints == 200)
        {
            spawnRate = 10;
        }

        if (isPlaying)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    
}
