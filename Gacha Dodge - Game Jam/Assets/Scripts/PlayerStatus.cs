using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int currentLife;
    private UIController uic;
    // Start is called before the first frame update
    void Start()
    {
        uic = FindObjectOfType<UIController>();
        currentLife = 3;
        Debug.Log("Current Life: " + currentLife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.tag == "Gacha")
        {
            currentLife -= 1;
            Debug.Log("Current Life: " + currentLife);
            uic.lifes[currentLife].SetActive(false);
        }
    }
}
