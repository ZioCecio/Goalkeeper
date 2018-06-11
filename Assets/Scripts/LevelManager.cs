using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance;
    public int level;
    public float difficult;

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        level = 0;
        difficult = 0f;
    }
}
