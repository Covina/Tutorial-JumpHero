using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    // The Player prefab
    [SerializeField]
    private GameObject player;

    // The Platform prefab
    [SerializeField]
    private GameObject platform;


    // Coordinate boundaries for creating the platforms
    private float minX = -2.3f;
    private float maxX = 2.3f;
    private float minY = -4.7f;
    private float maxY = -3.7f;


    private bool lerpCamera;
    private float lerpTime = 1.5f;
    private float lerpX;


    // 
    void Awake()
    {
        MakeInstance();
    }

    // Create static instance of GameManager
    private void MakeInstance()
    {
        if (instance == null) {
            instance = this;
        }
        
    }


    // Use this for initialization
    void Start () {
        CreateInitialPlatforms();

    }
	
	// Update is called once per frame
	void Update () {

        // Are we moving the camera?
        if (lerpCamera)
        {
            LerpTheCamera();
        }


	}


    void CreateInitialPlatforms()
    {
        // Generte starting location of first platform, clamp the X a bit
        Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY, maxY), 0f);

        // Spawn the platform
        Instantiate(platform, temp, Quaternion.identity);

        // Generate location for player, move Y coord up 3 units
        temp.y += 3f;

        // Spawn player on top of this starting platform
        Instantiate(player, temp, Quaternion.identity);


        // Generate location for second platform
        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0f);

        // Spawn the second platform
        Instantiate(platform, temp, Quaternion.identity);


    }

    // Create a new platform on which the player should jump
    private void CreateNewPlatform()
    {

        // Get the current X pos of the camera
        float cameraX = Camera.main.transform.position.x;

        // double screen width then add the camera X pos to find its location in the new view
        float newMaxX = (maxX * 2) + cameraX;

        // Create the new platform
        Instantiate(platform, new Vector3 (Random.Range(newMaxX, newMaxX - 1.2f), Random.Range(maxY, maxY - 1.2f), 0f), Quaternion.identity);

    }

    // Camera movement function
    private void LerpTheCamera()
    {
        // Get camera's current position   
        float x = Camera.main.transform.position.x;

        // calculate the nwe value of X Pos
        x = Mathf.Lerp(x, lerpX, lerpTime * Time.deltaTime);

        // Set new camera X position
        Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        // if camera has moved almost the entire way, disable the movement
        if(Camera.main.transform.position.x >= (lerpX - 0.07f))
        {
            // Turn off lerping   
            lerpCamera = false;

        }

    }

    // Create the platform and move the camera.
    public void CreateNewPlatformAndLerp(float lerpPosition)
    {
        // Calculate new final X position
        lerpX = lerpPosition + maxX;

        // turn on camera movement
        lerpCamera = true;

        // spawn the new platform
        CreateNewPlatform();


    }



}
