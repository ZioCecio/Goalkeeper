using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybindManager : MonoBehaviour {

    public static KeybindManager Km;

    public KeyCode tl { get; set; }
    public KeyCode ml { get; set; }
    public KeyCode bl { get; set; }
    public KeyCode tc { get; set; }
    public KeyCode bc { get; set; }
    public KeyCode tr { get; set; }
    public KeyCode mr { get; set; }
    public KeyCode br { get; set; }

    void Awake()
    {
        /*if (Km == null)
        {
            DontDestroyOnLoad(gameObject);
            Km = this;
        }
        else if (Km != this)
        {
            Destroy(gameObject);
        }*/
        Km = this;
        //PlayerPrefs.DeleteAll();

        tl = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("topLeftKey", "Keypad7"));
        ml = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("middleLeftKey", "Keypad4"));
        bl = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("bottomLeftKey", "Keypad1"));
        tc = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("topCenterKey", "Keypad8"));
        bc = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("bottomCenterKey", "Keypad2"));
        tr = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("topRightKey", "Keypad9"));
        mr = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("middleRightKey", "Keypad6"));
        br = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("bottomRightKey", "Keypad3"));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearControls()
    {
        PlayerPrefs.DeleteAll();
        tl = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("topLeftKey", "Keypad7"));
        ml = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("middleLeftKey", "Keypad4"));
        bl = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("bottomLeftKey", "Keypad1"));
        tc = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("topCenterKey", "Keypad8"));
        bc = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("bottomCenterKey", "Keypad2"));
        tr = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("topRightKey", "Keypad9"));
        mr = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("middleRightKey", "Keypad6"));
        br = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("bottomRightKey", "Keypad3"));
    }
}
