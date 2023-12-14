using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThePlayerLife : MonoBehaviour
{
    bool dead = false;
    int lives = 3;

    private Vector3 respawnPosition;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }

        // 'R' key press to restart the game
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body") && !dead)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerControl>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        lives--;
        Debug.Log("Lives Left: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), 1.3f);
        }
        dead = true;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<PlayerControl>().enabled = true;
        dead = false;
    }

    void RestartGame()
    {
       
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}