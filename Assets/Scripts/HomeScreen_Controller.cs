using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Home Screen Controller is working");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    // Function to play the game
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameView");
    }

    // Function to go to Instructions Screen
    public void Instructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions_View");
    }

    // Function to view the credits
    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits_View");
    }

    // Function for Return to go back to previous screen. In this case, it will go back to the main menu
    public void Return()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScreen");
    }


}
