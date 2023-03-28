using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public GameObject GameOverCanvas;
   public void GameOverScreen() => GameOverCanvas.SetActive(true);

   public void OnRestartButtonClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

   public void OnEscapeButtonClick()
   {
       Debug.Log("игра выключена");
       Application.Quit();
   }

}
