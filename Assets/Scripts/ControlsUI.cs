using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsUI : MonoBehaviour {

	void Update () {

        if (Input.GetKeyDown(KeybindManager.Km.tr))
        {
            GameManager.Instance.Click(4);
            Debug.Log("tr");
        }

        if (Input.GetKeyDown(KeybindManager.Km.tl))
        {
            GameManager.Instance.Click(5);
            Debug.Log("tl");
        }

        if (Input.GetKeyDown(KeybindManager.Km.tc))
        {
            GameManager.Instance.Click(6);
            Debug.Log("tc");
        }

        if (Input.GetKeyDown(KeybindManager.Km.ml))
        {
            GameManager.Instance.Click(0);
            Debug.Log("ml");
        }

        if (Input.GetKeyDown(KeybindManager.Km.mr))
        {
            GameManager.Instance.Click(1);
            Debug.Log("mr");
        }

        if (Input.GetKeyDown(KeybindManager.Km.bl))
        {
            GameManager.Instance.Click(2);
            Debug.Log("bl");
        }

        if (Input.GetKeyDown(KeybindManager.Km.bc))
        {
            GameManager.Instance.Click(7);
            Debug.Log("bc");
        }

        if (Input.GetKeyDown(KeybindManager.Km.br))
        {
            GameManager.Instance.Click(3);
            Debug.Log("br");
        }
    }
}
