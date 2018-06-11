using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	public static ScoreUI Instance;

	[SerializeField]
	private int score;

	[SerializeField]
	private Text scoreText;

	void Awake(){

		Instance = this;
	}

	void Start(){

		score = 0;
		UpdateScore ();
	}

	public void IncrementScore(){

		score++;
		UpdateScore ();
	}

	public void DecrementScore(){

		score = (score > 0)? (--score) : 0;
		UpdateScore ();
	}

	public int GetScore(){

		return score;
	}

	private void UpdateScore(){

		scoreText.text = score.ToString ();
	}

    public void ResetScore()
    {
        score = 0;
    }
}
