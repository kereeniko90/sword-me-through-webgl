using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    public logicScript logic;
    public GameObject sword;

    public bool gameOver;
    
    private bool triggered;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (triggered == false)
            {
                sword.GetComponent<swordScript>().notGameOver = false;
                logic.gameOver();
                triggered = true;
                

            }
        }



    }
}
