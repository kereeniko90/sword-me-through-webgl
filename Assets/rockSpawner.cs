using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawner : MonoBehaviour
{
    public float spawnRate = 2;
    public int spawnNumber = 0;
    private float timer = 0;
    //float topOffset = 10;
    //float botOffset = 10;
    public logicScript logic;
    public GameObject rock;
    public GameObject[] rockPrefab;
    private float spawnDifficulty = 0;
    private float defaultTimer = 1.1f;
    private float currentDifficulty = 0;
    public Vector3 lastRockPos;
    


    void Start()
    {
        //int rockVariation = Random.Range(0, Mathf.FloorToInt(spawnDifficulty));
        int rockVariation = Random.Range(0, 8);
        float topOffset = Random.Range(5, 10);
        float botOffset = Random.Range(5, 10);
        float lowestPoint = transform.position.y - botOffset;
        float highestPoint = transform.position.y + topOffset;
        Instantiate(rockPrefab[rockVariation], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();


    }


    // Update is called once per frame
    void Update()
    {
        spawnDifficulty = logic.spawnDifficulty;
        currentDifficulty = logic.currentDifficulty;

        if (spawnRate > 0.1)
        {
            spawnRate = defaultTimer - (spawnDifficulty * 0.1f);
        }
        
        

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnRock();
            
            timer = 0;
        }


    }

    void spawnRock()
    {
        

        int rocksToSpawn = Mathf.FloorToInt(spawnDifficulty);
        float lastPos = 0;
        

        
            
        //int rockVariation = Random.Range(0, Mathf.FloorToInt(spawnDifficulty));
        int rockVariation = Random.Range(0, 8);
        float newYpos = Random.Range(-11, 11);

        if (newYpos == lastPos && newYpos < 0 )
        {
            newYpos = lastPos + 6;
        }
        else if (newYpos == lastPos && newYpos > 0 ) 
        {
            newYpos = lastPos - 6;
        }
            //float topOffset = Random.Range(0 , 10);
            //float botOffset = Random.Range(0 , 10);
            //float lowestPoint = transform.position.y - botOffset;
            //float highestPoint = transform.position.y + topOffset;
            //Vector3 newPos = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z);
            //Vector3 newLocation = newPos - lastRockPos;

            // check distance to last spawned rock

         Instantiate(rockPrefab[rockVariation], new Vector3(transform.position.x, newYpos, transform.position.z), transform.rotation);
         lastPos = newYpos;
            
        
        




    }
}
