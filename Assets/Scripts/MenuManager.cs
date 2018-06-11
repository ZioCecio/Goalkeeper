using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void SelectLevel(int level)
    {
        LevelManager.Instance.level = level;
        Play();
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
