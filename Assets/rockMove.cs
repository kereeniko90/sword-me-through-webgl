using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class rockMove : MonoBehaviour
{
    private float moveSpeed;
    private float moveRange;
    private float rotateForce;
    private float startY;
    private float amplitude;
    public float levelMultiplier;
    public float destroyZone = -20;
    private Rigidbody2D rock;
    public logicScript logic;
    




    // Start is called before the first frame update
    void Start()
    {

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();

        levelMultiplier = logic.currentDifficulty;

        rock = GetComponent<Rigidbody2D>();
        
        moveSpeed = Random.Range(6.0f + levelMultiplier, 8.0f + levelMultiplier);
        rotateForce = Random.Range(15.0f + levelMultiplier, 30.0f + levelMultiplier) * moveSpeed;
        moveRange = Random.Range(5 * levelMultiplier, 10 * levelMultiplier);
        startY = transform.position.y; // save y starting position

    }

    // Update is called once per frame
    void Update()
    {
        


        float newYPos = Mathf.Sin(Time.time) * (moveRange/3);
        //Vector3 newPos = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;//no up and down movement
        Vector3 newPos = transform.position + (Vector3.left * moveSpeed + Vector3.up * newYPos) * Time.deltaTime;
        transform.position = newPos;
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        rock.AddTorque(rotateForce * Time.deltaTime);

        if (transform.position.x < destroyZone)
        {
            Destroy(gameObject);
        }
    }
}
