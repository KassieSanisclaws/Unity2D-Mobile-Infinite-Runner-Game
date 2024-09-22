using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YouWinGame_Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the player's score from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("PlayerScore", 0);

        // Display the final score on the UI
        scoreText.text = "Final Score: " + finalScore.ToString();
    }
}
