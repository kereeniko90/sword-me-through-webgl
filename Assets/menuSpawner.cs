using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSpawner : MonoBehaviour
{
    
    private float timer = 0;
    public float musicTimer = 0;
    //float topOffset = 10;
    //float botOffset = 10;
    public float spawnRate = 3;
    public GameObject rock;
    public GameObject[] rockPrefab;
    public AudioSource music;
    private float lastPos = 0;



    void Start()
    {


        music = music.GetComponent<AudioSource>();
        music.Play();


    }


    // Update is called once per frame
    void Update()
    {
        musicTimer = musicTimer + Time.deltaTime;


        if (musicTimer < 30)
        {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnRock();
                if (spawnRate >= 0.2f)
                {
                    spawnRate = Random.Range(3, 6);
                }
                timer = 0;
            }
        }
        else
        {
            spawnRate = 0.5f;
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

        if (musicTimer > 72) 
        {
            musicTimer = 0;
        }

    }

    void spawnRock()
    {

            float newYpos = Random.Range(5, 10);

            if (newYpos == lastPos && newYpos < 0)
            {
                newYpos = lastPos + 3;
            }
            else if (newYpos == lastPos && newYpos > 0)
            {
                newYpos = lastPos - 3;
            }


            int rockVariation = Random.Range(0, 8);
            float topOffset = Random.Range(5, 10);
            float botOffset = Random.Range(5, 10);
            float lowestPoint = transform.position.y - botOffset;
            float highestPoint = transform.position.y + topOffset;
            Instantiate(rockPrefab[rockVariation], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
            lastPos = newYpos;
        }





    

}
