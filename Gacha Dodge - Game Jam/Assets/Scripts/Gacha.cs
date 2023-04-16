using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    private float minSpeed, maxSpeed, speed;
    public GameObject[] goToPoints;

    [SerializeField]private GameObject goToPoint;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        minSpeed = 5;
        maxSpeed = 20;
        goToPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        goToPoint = goToPoints[Random.Range(0,goToPoints.Length - 1)];
        dir = new Vector2(goToPoint.transform.position.x, goToPoint.transform.position.y);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if(transform.position.x == dir.x && transform.position.y == dir.y)
        {
            Destroy(this.gameObject);
        }
    }
}