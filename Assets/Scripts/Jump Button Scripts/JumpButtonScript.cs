using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public void OnPointerDown(PointerEventData data)
    {
        // debug
        //Debug.Log("We are touching the button");

        // When we press, set the SetPower
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.SetPower(true);
        }

    }

    public void OnPointerUp(PointerEventData data)
    {
        // debug
        //Debug.Log("We have released the button");

        // When we release, unset the SetPower
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.SetPower(false);
        }
    }


}
