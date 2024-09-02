using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject[] rocks;
    public float spawnRate = 3;
    public int spawnNumber = 0;
    private float timer = 0;
    public float topOffset1 = 3;
    public float botOffset1 = 1;
    public float topOffset2 = 4;
    public float botOffset2 = 4;


    void Start()
    {
        spawnBoulder();
    }

    // Update is called once per frame
    void Update()
    {
        spawnNumber = Random.Range(0, 4);
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnBoulder();
            timer = 0;
        }
        
       
    }

    void spawnBoulder()
    {
        float lowestPoint1 = transform.position.y - botOffset1;
        float highestPoint1 = transform.position.y + topOffset1;

        float lowestPoint2 = transform.position.y - botOffset2;
        float highestPoint2 = transform.position.y + topOffset2;



        Instantiate(rocks[spawnNumber], new Vector3(transform.position.x, Random.Range(lowestPoint1, highestPoint1), 0), transform.rotation);
        
    }
}
