using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver_Controller : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
       // Retreive the players score from the PlayerPerfs
       int finalScore = PlayerPrefs.GetInt("PlayerScore", 0);

      // Display the score on the screen
      scoreText.text = "Score: " + finalScore.ToString();
    }

}
