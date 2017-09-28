using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public static GameOverManager instance;

    // The entire Game Over panel
    [SerializeField]
    private GameObject gameOverPanel;

    // the animator to control the fade in
    private Animator gameOverAnim;

    // Play Again
    [SerializeField]
    private Button buttonPlayAgain;

    // Return to main menu
    [SerializeField]
    private Button buttonBack;

    // the score of the player
    [SerializeField]
    private Text textFinalScoreValue;


    private GameObject activeScoreTextDisplay;
    private GameObject activeScoreValueDisplay;

    // Use this for initialization
    void Awake () {
        // create singleton
        MakeInstance();

        // Set vars
        InitializeVariables();

    }
	
    // Create singleton
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    // Set needed variables
    private void InitializeVariables()
    {
        // Get the animator
        gameOverAnim = gameOverPanel.GetComponent<Animator>();

        // Disable the game over panel
        gameOverPanel.SetActive(false);

        // The display of the player's current score as they play
        activeScoreTextDisplay = GameObject.Find("ActiveScoreLabel");
        activeScoreValueDisplay = GameObject.Find("ActiveScoreValue");


    }


    // Reload the Gameplay scene
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Send player to Main Menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOverShowPanel()
    {

        // Disable the player's active game score display
        activeScoreTextDisplay.SetActive(false);
        activeScoreValueDisplay.SetActive(false);

        // Display the player's final score
        textFinalScoreValue.text = ScoreManager.instance.Score.ToString();


        // enable the game over panel
        gameOverPanel.SetActive(true);

        // Play the panel animation
        gameOverAnim.Play("FadeIn");

    }

}
