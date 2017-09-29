using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour {

    // TODO: Add indicator of power required 
    // TODO: Prevent scoring and spawning of new platforms when jumping on same platform


    public static PlayerJumpScript instance;

    // Player RigidBody2D (At the feet)
    private Rigidbody2D myBody;

    // Player animator to manage animations
    private Animator anim;

    private float forceX, forceY;

    private float thresholdX = 7f;
    private float thresholdY = 14f;

    private bool setPower;
    private bool didJump;

    // Gameobject for the powerbar slider
    private Slider powerBar;
    
    // how high the power can go
    private float powerBarThreshold = 10f;

    // the current value of the bar
    private float powerBarValue = 0f;


    void Awake()
    {
        // create singleton
        MakeInstance();

        // Init all the game object and component references
        Initialize();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ApplyPower();
    }

    // Make all the initial game object connections
    private void Initialize()
    {
        // get the Rigidbody attached to the Player game object
        myBody = GetComponent<Rigidbody2D>();

        // get the Animator on the Player game object
        anim = GetComponent<Animator>();

        // Get the power bar game object
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();

        // Set its starting values
        powerBar.minValue = 0f;
        powerBar.maxValue = 10f;
        powerBar.value = powerBarValue;

    }


    // Create static instance of the class
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;

        }

    }


    private void ApplyPower()
    {
        // Check if setPower is TRUE
        if (setPower)
        {
            //Debug.Log("We are setting the power");

            // set the power values
            forceX += thresholdX * Time.deltaTime;
            forceY += thresholdY * Time.deltaTime;



            /*
            if (forceX >= 6.5f)
            {
                forceX = 6.5f;
            }

            if (forceX <= 2f)
            {
                forceX = 2f;
            }
            */


            // Cap the ForceY
            if (forceY >= 13.5f)
            {
                forceY = 13.5f;
            }

            if (forceY <= 4f)
            {
                forceY = 4f;
            }

            // Get the current power bar value
            powerBarValue += powerBarThreshold * Time.deltaTime;

            // Update the slider visual
            powerBar.value = powerBarValue;


        }

    }

    public void SetPower(bool setPower)
    {
        // set the class variable to the passed argument value   
        this.setPower = setPower;

        // if we are not setting the power, jump!
        if (!setPower)
        {
            Jump();
        }

    }

    // Jump function
    private void Jump()
    {

        // check to make sure player isn't already jumping
        if(!didJump) {

            // make the player jump
            myBody.velocity = new Vector2(forceX, forceY);

            // reset the force values to zero
            forceX = forceY = 0f;

            // set didJump status
            didJump = true;

            powerBarValue = 0f;
            powerBar.value = powerBarValue;

            // Set the bool so the Player jump animation plays
            anim.SetBool("isJumping", didJump);

            
        }

    }

    // Check for collision only if previously jumped
    void OnTriggerEnter2D(Collider2D target)
    {

        if (didJump)
        {
            // reset the value
            didJump = false;

            // Check to see if player landed on the platform
            if (target.tag == "Platform")
            {

                anim.SetBool("isJumping", didJump);

                Debug.Log("Player collided with the platform");

                if(GameManager.instance != null) {

                    // move the camera to the X position of the second platform.
                    GameManager.instance.CreateNewPlatformAndLerp(target.transform.position.x);

                }

                // Add to player score
                if(ScoreManager.instance != null)
                {
                    ScoreManager.instance.IncrementScore();
                }


            }

        }

        // Player has passed through a DeathZone
        if (target.tag == "DeathZone")
        {

            // Destroy player object
            DestroyObject(gameObject);

            // End the game   
            GameOverManager.instance.GameOverShowPanel();
        }

    }


}
