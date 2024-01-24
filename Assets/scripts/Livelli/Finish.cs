using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource finishSound;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Personaggio" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);    
        }
    }

    private void CompleteLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5) {
            if(Timer.score > 0) {
                Play_Leaderboard.SendLeaderboard("TimeScoreHorizontal", Timer.score);
            }
            Timer.elapsedTime = 0.0f;
            SceneManager.LoadScene(10); // scena finale
        } else if(SceneManager.GetActiveScene().buildIndex == 8) {
            if(Timer.score > 0) {
                Play_Leaderboard.SendLeaderboard("TimeScoreVertical", Timer.score);
            }
            Timer.elapsedTime = 0.0f;
            SceneManager.LoadScene(10); // scena finale
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // prossimo livello
        }
        
    }

}
