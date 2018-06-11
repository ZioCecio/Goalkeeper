using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance;
    public int level;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        level = 0;
    }
}
