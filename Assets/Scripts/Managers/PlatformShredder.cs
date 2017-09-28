using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShredder : MonoBehaviour
{

    // Cleanup the platforms that go off screen to the left
    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Shredder collided with [" + target.name + "]");

        // Destroy platforms
        if (target.tag == "Platform")
        {
            //Debug.Log("Platform collided with Shredder");
            Destroy(target.gameObject);
        }

    }


}