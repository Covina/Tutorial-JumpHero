using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour {

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


    void Awake()
    {


    }

    // Create static instance of the class
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;

        }

    }


    public void SetPower(bool setPower)
    {
        // set the class variable to the passed argument value   
        this.setPower = setPower;

        // Check if setPower is TRUE
        if(setPower)
        {
            Debug.Log("We are setting the power");
        } else {

            // do something
            Debug.Log("We are NOT setting the power");

        }

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
