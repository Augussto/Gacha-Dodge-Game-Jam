using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewLife : MonoBehaviour
{
    public GameObject[] specialObject;

    [SerializeField] private GameObject[] spawnPoints;
    private GameObject spawnPoint;

    private GameManager gm;

    private int numberToSpawn;
    private int randNum;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        gm = GetComponent<GameManager>();
        numberToSpawn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isPlaying)
        {
            randNum = Random.Range(0, 1000);
            if (randNum == numberToSpawn)
            {
                SpawnGacha();
            }
        }
    }

    private void SpawnGacha()
    {
        randNum = Random.Range(0, specialObject.Length);
        spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(specialObject[randNum], spawnPoint.transform.position, Quaternion.identity);
    }
}
