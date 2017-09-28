using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    // the Score label text object
    [SerializeField]
    private Text textScoreLabel;

    // the Score number text object
    [SerializeField]
    private Text textScoreValue;

    // The player's actual score
    private int score;

    // Getter/setter for Score
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    // Use this for initialization
    void Awake () {

        MakeInstance();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // generate singleton
    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IncrementScore()
    {
        // increment the score
        score++;

        // Update the score value
        textScoreValue.text = score.ToString();

    }

    
}
