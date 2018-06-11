using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsUI : MonoBehaviour {

	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
            GameManager.Instance.Click(5);

        if (Input.GetKeyDown(KeyCode.W))
            GameManager.Instance.Click(6);

        if (Input.GetKeyDown(KeyCode.E))
            GameManager.Instance.Click(4);

        if (Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.Click(0);

        if (Input.GetKeyDown(KeyCode.D))
            GameManager.Instance.Click(1);

        if (Input.GetKeyDown(KeyCode.Z))
            GameManager.Instance.Click(2);

        if (Input.GetKeyDown(KeyCode.X))
            GameManager.Instance.Click(7);

        if (Input.GetKeyDown(KeyCode.C))
            GameManager.Instance.Click(3);
    }
}
