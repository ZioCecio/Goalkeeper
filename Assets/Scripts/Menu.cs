using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {



    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
    public void QuitGame()
    {
        Debug.Log("Game Closed!");
        Application.Quit();
    }
}
