using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
      [SerializeField] GameObject pauseMenu;
      public static bool isPaused;
   
     
   
   public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.volume = 0;
          
   }

   public void Home() {
        SceneManager.LoadScene(2);
           Time.timeScale = 1f;
            Timer.elapsedTime = 0f;
          isPaused = false;
          if (AudioManager.isMuted == false)
               AudioListener.volume = 1;
   }

   public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
         isPaused = false;
          if (AudioManager.isMuted == false)
               AudioListener.volume = 1;
   }

   public void Restart() {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         Timer.elapsedTime += 1.5f;
         Time.timeScale = 1f;
         isPaused = false;
          if (AudioManager.isMuted == false)
               AudioListener.volume = 1;
   }
}
