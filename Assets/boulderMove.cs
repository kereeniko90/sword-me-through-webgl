using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boulderMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float destroyZone = -100;
    //public Text testText;
    //private float xPosition = 0;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //xPosition = transform.position.x;
        //testText = xPosition.ToString();

        //Debug.Log(transform.position.x);

        if (transform.position.x < destroyZone)
        {
           Destroy(gameObject);
        }
    }
}
