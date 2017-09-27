using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // Simple load scene function to start the game
    public void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
