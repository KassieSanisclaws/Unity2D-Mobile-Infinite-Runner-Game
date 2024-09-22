using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2_GameView_Manager : MonoBehaviour
{
    public GameObject star;
    public GameObject dragonFire;
    public GameObject pokeEgg;
    public GameObject pokeStarball;

    public float max_X;
    public Transform spawnPoint;
    public Transform dragonFireSpawnPoint;
    public Transform pokeEggSpawnPoint;
    public Transform pokeStarballSpawnPoint;

    public float spawnRate;

    public Player_Controller player;

    private Camera cam;
    private float minY, maxY;
    private int winScore = 1000; // The score the player needs to reach to win the game.

    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    int scoreCount = 0;


    void Start()
    {
        cam = Camera.main;

        // Calculate the camera's Y boundaries based on screen view
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        minY = bottomLeft.y + 1f; // Add some padding to avoid spawning too close to the bottom
        maxY = topRight.y - 1f;   // Add padding to avoid spawning too high
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameStarted)
        {
            StartSpawningStars(); // Start spawning the stars when the player taps the screen.
            StartSpawningDragonFire(); // Start spawning the dragon fire when the player taps the screen.

            if (pokeEgg != null && pokeEggSpawnPoint != null) StartSpawningPokeEgg();
            if (pokeStarball != null && pokeStarballSpawnPoint != null) StartSpawningPokeStarball();

            gameStarted = true; // Set the gameStarted to true when the player taps the screen.
            tapText.SetActive(false); // Deactivate the tapText game object when the game starts.
        }

        // Check if the player has reached the winScore
        if (scoreCount >= winScore)
        {
            HandleLevelCleared();
        }

    }

    public void StartSpawningStars()
    {
        InvokeRepeating("SpawnStars", 0.5f, spawnRate);
    }

    private void SpawnStars()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-max_X, max_X);
        //spawnPos.y = Random.Range(minY, maxY); // Randomize the Y position within the camera's boundaries
        Instantiate(star, spawnPos, Quaternion.identity);
        IncreaseScore(1); // Increase the score by 1 when the star is spawned.
        Debug.Log("Star Spawned at Position: " + spawnPos);  // Log the spawn position
        scoreCount++;
        scoreText.text = scoreCount.ToString(); // Convert the scoreCount to string then setting the UI text value to the UI text component on screen.
    }

    public void StartSpawningDragonFire()
    {
        InvokeRepeating("SpawnDragonFire", 1.5f, spawnRate);
    }

    private void SpawnDragonFire()
    {
        Vector3 spawnPos = dragonFireSpawnPoint.position;
        spawnPos.x = Random.Range(-max_X, max_X);
        //spawnPos.y = Random.Range(minY, maxY); // Randomize the Y position within the camera's boundaries
        Instantiate(dragonFire, spawnPos, Quaternion.identity);
        Debug.Log("DragonFire Spawned at Position: " + spawnPos);  // Log the spawn position
    }

    public void StartSpawningPokeEgg()
    {
        InvokeRepeating("SpawnPokeEgg", 1.5f, spawnRate);
    }

    private void SpawnPokeEgg()
    {
        if (pokeEgg != null && pokeEggSpawnPoint != null)
        {
            Vector3 spawnPos = pokeEggSpawnPoint.position;
            spawnPos.x = Random.Range(-max_X, max_X);
            //spawnPos.y = Random.Range(minY, maxY); // Randomize the Y position within the camera's boundaries
            Instantiate(pokeEgg, spawnPos, Quaternion.identity);
            Debug.Log("PokeEgg Spawned at Position: " + spawnPos);  // Log the spawn position
        }
    }

    public void StartSpawningPokeStarball()
    {
        InvokeRepeating("SpawnPokeStarball", 1.5f, spawnRate);
    }

    private void SpawnPokeStarball()
    {
        if (pokeStarball == null || pokeStarballSpawnPoint == null) return;
        Vector3 spawnPos = pokeStarballSpawnPoint.position;
        spawnPos.x = Random.Range(-max_X, max_X);
        //spawnPos.y = Random.Range(minY, maxY); // Randomize the Y position within the camera's boundaries
        Instantiate(pokeStarball, spawnPos, Quaternion.identity);
        Debug.Log("PokeStarball Spawned at Position: " + spawnPos);  // Log the spawn position
    }

    public void IncreaseScore(int incrementScore)
    {
        scoreCount += incrementScore;
        scoreText.text = scoreCount.ToString(); // Convert the scoreCount to string then setting the UI text value to the UI text component on screen.
                                                // CHeck the score to see if the player has reached the winScore
        if (scoreCount >= winScore)
        {
            HandleLevelCleared();
        }
    }
    public void HandleLevelCleared()
    {
        PlayerPrefs.SetInt("PlayerScore", scoreCount);
        PlayerPrefs.Save(); // Save the player score to the device.
        UnityEngine.SceneManagement.SceneManager.LoadScene("YouWin_View");
    }

    public int GetScore()
    {
        return scoreCount;
    }

}
