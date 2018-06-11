using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager Instance;

	[SerializeField] private List<GameObject> points = new List<GameObject>();
    [SerializeField] private List<GameObject> goalkeepers = new List<GameObject>();
    [SerializeField] private Sprite ball;
    [SerializeField] private float reactionTimer;
    [SerializeField] private Sprite knob;
    [SerializeField] private List<bool> flags;
    [SerializeField] private List<GameObject> lifes = new List<GameObject>();
    [SerializeField]private List<GameObject> crosses = new List<GameObject>();

    private int selectedPointIndex;
    public List<float> reactionTimes;
	private bool sleep;
	private float maxWait;
	private bool clicked;
    private int selectedGoalkeeperIndex;
    private List<int> activePoints;
    private bool lost;
    private bool isFirstTime;
    private int errorCount;

    private int mod;

	void Awake(){
		Instance = this;
	}

	void Start(){
        mod = LevelManager.Instance.level;

        reactionTimes = new List<float>();
		maxWait = 1f;
		clicked = false;
		sleep = false;
        lost = false;
        isFirstTime = true;
        activePoints = new List<int>();
        errorCount = 0;

        if(mod == 0)
        {
            Timer.Instance.isStopwatch(false);
        }
        else if(mod == 1)
        {
            Timer.Instance.isStopwatch(true);
        }
        else if(mod == 2)
        {
            Timer.Instance.isStopwatch(true);
            activePoints.Add(0);
            activePoints.Add(1);
            ChangeActivePoints();
        }
        else if(mod == 3)
        {
            Timer.Instance.isStopwatch(true);
            foreach (GameObject ob in lifes)
                ob.gameObject.SetActive(true);
        }
    }

	void Update(){
        if (sleep)
            return;

        if (mod == 0)
            UpdateMod0();
        if(mod == 1)
            UpdateMod1();
        if(mod == 2)
            UpdateMod2();
        if (mod == 3)
            UpdateMod3();
    }

	public void Click(int id){
		if (clicked)
			return;

        if (mod == 2 && !activePoints.Contains(id))
            return;

        goalkeepers[8].gameObject.SetActive(false);
        goalkeepers[id].gameObject.SetActive(true);
        selectedGoalkeeperIndex = id;

        if (id == selectedPointIndex) {
			ScoreUI.Instance.IncrementScore ();
			points [selectedPointIndex].GetComponent<SpriteRenderer>().color = Color.white;
            StartCoroutine ("InterSelectPoint");
		} else {
            if (mod == 0)
            {
                ScoreUI.Instance.DecrementScore();
                StartCoroutine("InterSelectPoint");
            }
            else if (mod == 1)
                StartCoroutine("InterSelectPoint");
            else if (mod == 2)
            {
                ScoreUI.Instance.DecrementScore();
                StartCoroutine("InterSelectPoint");
            }
            else if (mod == 3)
            {
                StartCoroutine("InterSelectPoint");
                crosses[errorCount].gameObject.SetActive(true);
                errorCount++;
            }
		}

        points[selectedPointIndex].GetComponent<SpriteRenderer>().sprite = ball;

        clicked = true;
	}

	private IEnumerator InterSelectPoint(){
		StopReactionTimer ();

		sleep = true;
		yield return new WaitForSeconds (1f);
		sleep = false;

        if(mod == 2)
            SelectPointGame3();
        else
		    SelectPoint ();
	}

	private void SelectPoint(){
		foreach (GameObject ob in points) {
			ob.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5960f);
            ob.GetComponent<SpriteRenderer>().sprite = knob;
        }

		selectedPointIndex = Random.Range (0,7);
		points [selectedPointIndex].GetComponent<SpriteRenderer> ().color = Color.red;

		clicked = false;

		ResetReactionTimer();

        goalkeepers[selectedGoalkeeperIndex].gameObject.SetActive(false);
        goalkeepers[8].gameObject.SetActive(true);
    }

    private void ChangeActivePoints()
    {
        foreach (GameObject ob in points)
        {
            if (!activePoints.Contains(ob.name.ToCharArray()[0] - '0'))
                ob.gameObject.SetActive(false);
            else
            {
                ob.gameObject.SetActive(true);
                if(ob.name.ToCharArray()[0] - '0' != selectedPointIndex)
                    ob.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5960f);
                ob.GetComponent<SpriteRenderer>().sprite = knob;
            }
        }
    }

    private void SelectPointGame3()
    {
        foreach(int i in activePoints)
        {
            points[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5960f);
            points[i].GetComponent<SpriteRenderer>().sprite = knob;
        }

        selectedPointIndex = activePoints[Random.Range(0, activePoints.Count)];
        points[selectedPointIndex].GetComponent<SpriteRenderer>().color = Color.red;

        clicked = false;

        ResetReactionTimer();

        goalkeepers[selectedGoalkeeperIndex].gameObject.SetActive(false);
        goalkeepers[8].gameObject.SetActive(true);
    }

	private void ResetReactionTimer(){
		reactionTimer = 0f;
	}

	private bool RefreshReactionTimer(){
		reactionTimer += Time.deltaTime;

		if (reactionTimer >= maxWait) {
			return false;
		}
		return true;
	}

	private void StopReactionTimer(){
		if (reactionTimer != 0f) {
			reactionTimes.Add ((reactionTimer > maxWait)? maxWait : reactionTimer);
		}
	}

    private void UpdateMod0()
    {
        if (!RefreshReactionTimer())
        {
            ScoreUI.Instance.DecrementScore();
            SelectPoint();
        }

        if(Timer.Instance.isStopped())
        {
            sleep = true;
            clicked = true;
            SceneManager.LoadScene(2);
        }
    }

    private void UpdateMod1()
    {
        if (!RefreshReactionTimer())
            SelectPoint();

        if (ScoreUI.Instance.GetScore() >= 10)
        {
            Timer.Instance.Stop();
            sleep = true;
            clicked = true;
            SceneManager.LoadScene(2);
        }
    }

    private void UpdateMod2()
    {
        if (ScoreUI.Instance.GetScore() >= 5 && !flags[0])
        {
            activePoints.Remove(0);
            activePoints.Remove(1);
            activePoints.Add(2);
            activePoints.Add(3);
            activePoints.Add(4);
            activePoints.Add(5);
            ChangeActivePoints();
            flags[0] = true;
        }
        else if (ScoreUI.Instance.GetScore() < 5 && flags[0])
        {
            activePoints.Clear();
            activePoints.Add(0);
            activePoints.Add(1);
            ChangeActivePoints();
            flags[0] = false;
        }

        if (ScoreUI.Instance.GetScore() >= 10 && !flags[1])
        {
            activePoints.Add(0);
            activePoints.Add(1);
            ChangeActivePoints();
            flags[1] = true;
        }
        else if (ScoreUI.Instance.GetScore() < 10 && flags[1])
        {
            activePoints.Remove(0);
            activePoints.Remove(1);
            ChangeActivePoints();
            flags[1] = false;
        }

        if (ScoreUI.Instance.GetScore() >= 15 && !flags[2])
        {
            activePoints.Add(6);
            activePoints.Add(7);
            ChangeActivePoints();
            flags[2] = true;
        }
        else if (ScoreUI.Instance.GetScore() < 15 && flags[2])
        {
            activePoints.Remove(6);
            activePoints.Remove(7);
            ChangeActivePoints();
            flags[2] = false;
        }

        if (!RefreshReactionTimer())
            SelectPointGame3();

        if (ScoreUI.Instance.GetScore() >= 20)
        {
            sleep = true;
            clicked = true;
            Timer.Instance.Stop();
            SceneManager.LoadScene(2);
        }
    }

    private void UpdateMod3()
    {
        if (isFirstTime)
        {
            SelectPoint();
            isFirstTime = false;
        }
        if (!RefreshReactionTimer())
        {
            crosses[errorCount].gameObject.SetActive(true);
            errorCount++;
            SelectPoint();
        }

        if (errorCount >= 3)
            lost = true;

        if (lost)
        {
            sleep = true;
            clicked = true;
            Timer.Instance.Stop();
            SceneManager.LoadScene(2);
        }
    }
}
