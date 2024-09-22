using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;

    public GameView_Manager gameManager;
    public Level2_GameView_Manager level2GameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("This is the:" + gameObject.name);
        Debug.Log("started");
       
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
           // Convert the mouse position from screen point to world point
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.x < 0)
            {
                rb.AddForce( Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce( Vector2.right * moveSpeed);
            }
            
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.y,0);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            PlayerPrefs.SetInt("PlayerScore", gameManager.GetScore());
            PlayerPrefs.Save(); // Save the player score to the device.
            Destroy(gameObject);
            SceneManager.LoadScene(4);
            rb.velocity = Vector2.zero;

        }
        else if (collision.gameObject.CompareTag("DragonFire"))
        {
            Destroy(collision.gameObject);
            gameManager.IncreaseScore(200);

        }
        else if (collision.gameObject.CompareTag("PokeEgg"))
        {
            Destroy(collision.gameObject);
            gameManager.IncreaseScore(150);
        }
        else if (collision.gameObject.CompareTag("PokeStarball"))
        {
            PlayerPrefs.SetInt("PlayerScore", gameManager.GetScore());
            PlayerPrefs.Save(); // Save the player score to the device.
            Destroy(gameObject);
            SceneManager.LoadScene(4);
            rb.velocity = Vector2.zero;
        }
        

       
    }

}
