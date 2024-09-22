using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Controller : MonoBehaviour
{
    // Function to go to Level2:
    public void LoadLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTWO");
    }
}
