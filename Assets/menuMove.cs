using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMove : MonoBehaviour
{
    private float moveSpeed;
    private float moveRange;
    private float rotateForce;
    private float startY;
    private float amplitude;
    
    
    public float destroyZone = -250;
    private Rigidbody2D rock;
    





    // Start is called before the first frame update
    void Start()
    {

        

        rock = GetComponent<Rigidbody2D>();
        float initialForce = Random.Range(1500f, 2000f);
        //float initialForce = 10f;
        rock.AddForce(Vector3.left * initialForce);

        //moveSpeed = Random.Range(6.5f, 12.0f);
        rotateForce = Random.Range(10.0f, 30.0f);
        //moveRange = Random.Range(5, 10);
        //startY = transform.position.y; // save y starting position

    }

    // Update is called once per frame
    void Update()
    {
        //rock.AddForce(Vector3.left * initialForce * Time.deltaTime);
        rock.AddTorque(rotateForce * Time.deltaTime);

        //Vector3 newPos = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        //transform.position = newPos;



        if (transform.position.x < destroyZone)
        {
            Destroy(gameObject);
        }
    }
}
