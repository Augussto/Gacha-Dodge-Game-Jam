using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPoints;
    public int spawnRate;

    private float timer;

    private PlayerStatus ps;
    private UIController uic;
    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
        spawnRate = 80;
        ps = FindObjectOfType<PlayerStatus>();
        uic = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.currentLife == 0)
        {
            uic.DefeatScreen();
        }
        timer += Time.deltaTime;
        currentPoints = (int) timer;

        if(currentPoints == 40)
        {
            spawnRate = 60;
        }
        else if(currentPoints == 80)
        {
            spawnRate = 40;
        }
        else if(currentPoints == 120)
        {
            spawnRate = 30;
        }
    }
}
