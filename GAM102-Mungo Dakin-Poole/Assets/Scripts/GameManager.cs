using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private float startTime;
   private float _time;
   public static GameManager instance { get; private set; }
    
   private void Awake()
   {
      if (instance != null)
      {
         Destroy(gameObject);
         return;
      }
      instance = this;

      _time = startTime;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      Time.timeScale = 1;
   }

   private void Update()
   {
      UIManager.instance.SetTime(_time);
      _time -= Time.deltaTime;
      
      if(Input.GetKeyDown(KeyCode.Escape)) Pause();
   }

   public void GoToMenu()
   {
      SceneManager.LoadScene(0);
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   private void Pause()
   {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      
      Time.timeScale = 0;
      UIManager.instance.Pause();
   }
   
   public void Resume()
   {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      
      Time.timeScale = 1;
      UIManager.instance.Resume();
   }

   public void GameOver(GameObject screen)
   {
      Time.timeScale = 0;
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      screen.SetActive(true);
   }
}
