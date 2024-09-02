using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public Rigidbody2D swordBody;
    public float flyStrength = 1;
    public float swordGravity = 3;
    public AudioSource swordAudioSource;
    public AudioSource crashSword;
    public AudioSource[] swordSoundEffects;
    public logicScript logic;
    public bool notGameOver = true;
    private bool isJumping = false;
    private bool endSound = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        //swordAudioSource = swordAudioSource.GetComponent<AudioSource>();
        //crashSword = gameObject.AddComponent<AudioSource>();
        swordAudioSource = swordSoundEffects.GetValue(0) as AudioSource;
        crashSword = swordSoundEffects.GetValue(1) as AudioSource;

    }

    // Update is called once per frame
    void Update()
    {
        float ySpeed = Mathf.Abs(swordBody.velocity.y);
        
        
        swordBody.gravityScale = swordGravity;

        


        //transform.Rotate(0f, 0f, -100 * Time.deltaTime);
        //swordBody.AddTorque(ySpeed);

        float torque = -1 * ySpeed * Time.deltaTime * (isJumping ? 450.0f : 20.0f);
        swordBody.AddTorque(torque);



        if ((Input.GetKeyDown(KeyCode.Space) == true || Input.touchCount > 0) && notGameOver == true)
        {
            swordBody.velocity = Vector2.up * 12.5f;
            isJumping = true;
            swordAudioSource.Play();
            //swordBody.AddTorque(ySpeed);
            //GetComponent<Transform>().eulerAngles = new Vector3 (0,0, swordRotation + ySpeed);



        }
        else
        {
            isJumping=false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        logic.gameOver();
        notGameOver = false;

        if (endSound == false)
        {
            crashSword.Play();
            endSound = true;
        }
        
        swordBody.angularVelocity *= 10;
    }

    
}
