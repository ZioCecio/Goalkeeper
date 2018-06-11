using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseReturn : MonoBehaviour {

    
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas scoreCanvas;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject goalkeepers;
    [SerializeField] private GameObject points;

    private bool paused = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Settings();
        }

    }

    public void Settings()
    {
        if (!paused)
        {
            paused = true;
       
            pauseCanvas.gameObject.SetActive(true);
            scoreCanvas.gameObject.SetActive(false);
            GameManager.gameObject.SetActive(false);
            Background.gameObject.SetActive(false);
            points.gameObject.SetActive(false);
            goalkeepers.gameObject.SetActive(false);

        }
        else
        {
            paused = false;

            pauseCanvas.gameObject.SetActive(false);
            scoreCanvas.gameObject.SetActive(true);
            GameManager.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            points.gameObject.SetActive(true);
            goalkeepers.gameObject.SetActive(true);

        }

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
