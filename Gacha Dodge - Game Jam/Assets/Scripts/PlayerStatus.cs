using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int currentLife;
    private UIController uic;
    private GameManager gm;
    private MusicController mc;

    public AudioSource hitGacha;
    public AudioSource hitLife;
    public AudioSource inGameSong;
    public AudioSource powerUpSong;
    // Start is called before the first frame update
    void Start()
    {
        uic = FindObjectOfType<UIController>();
        gm = FindObjectOfType<GameManager>();
        mc = FindObjectOfType<MusicController>();
        currentLife = 3;
        Debug.Log("Current Life: " + currentLife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.tag == "Gacha")
        {
            currentLife -= 1;
            uic.lifes[currentLife].SetActive(false);
            Destroy(collision.gameObject);
            hitGacha.Play();
        }
        else if(collision.tag == "Life")
        {
            if(currentLife == 2 || currentLife == 1)
            {
                uic.lifes[currentLife].SetActive(true);
                currentLife += 1;
                Destroy(collision.gameObject);
                hitLife.Play();
            }
        }
        else if(collision.tag == "Star" && gm.powerUp == false)
        {
            hitLife.Play();
            Destroy(collision.gameObject);
            gm.powerUp = true;
            uic.ChangeBg(gm.powerUp);
            Debug.Log("POWER UP");
            StartCoroutine("ActivatePowerUp");
        }
    }

    IEnumerator ActivatePowerUp()
    {
        while (gm.powerUp)
        {
            if (mc.activateMusic)
            {
                inGameSong.Stop();
                powerUpSong.Play();
            }
            yield return new WaitForSeconds(10f);
            gm.powerUp = false;
            uic.ChangeBg(gm.powerUp);
            if (mc.activateMusic)
            {
                powerUpSong.Stop();
                inGameSong.Play();
            }
            Debug.Log("END POWER UP");
        }
    }
}
