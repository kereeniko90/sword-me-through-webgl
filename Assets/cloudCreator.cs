using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cloudCreator : MonoBehaviour
{
    
    public float spawnRate = 1;
    public int spawnNumber = 0;
    private float timer = 0;
    public float topOffset = 10;
    public float botOffset = 10;
    public GameObject sword;
    public GameObject[] cloudPrefabs;


    void Start()
    {


        for (int i = 0; i < 30; i++)
        {
            int ranClouds = Random.Range(0, 6);
            float xOffset = Random.Range(-30, 30);
            float yOffset = Random.Range(-10, 10);
            Instantiate(cloudPrefabs[ranClouds], new Vector3(sword.transform.position.x + xOffset, sword.transform.position.y + yOffset, transform.position.z), transform.rotation);
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        spawnNumber = Random.Range(0, 6);
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnCloud();
            spawnRate = Random.Range(0.5f, 1f);
            timer = 0;
        }


    }

    void spawnCloud()
    {
        float lowestPoint = transform.position.y - botOffset;
        float highestPoint = transform.position.y + topOffset;
        float randomX = Random.Range(-3, 3);
        

        
        Instantiate(cloudPrefabs[spawnNumber], new Vector3(transform.position.x + randomX, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
        

        

    }
}
