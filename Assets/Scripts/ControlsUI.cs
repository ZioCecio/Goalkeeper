using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsUI : MonoBehaviour
{

    void Update()
    {

        float x = Input.GetAxis("X Axis");
        float y = Input.GetAxis("Y Axis");
        int x1 = (int)x;
        int y2 = (int)y;

        if (Input.GetKeyDown(KeybindManager.Km.mr) || (x1 == 1 && y2 == 0))
        {
            GameManager.Instance.Click(1);
        }


        if (Input.GetKeyDown(KeybindManager.Km.tc) || (y2 == 1 && x1 == 0))
        {
            GameManager.Instance.Click(6);
        }


        if (Input.GetKeyDown(KeybindManager.Km.bc) || (y2 == -1 && x1 == 0))
        {
            GameManager.Instance.Click(7);
        }


        if (Input.GetKeyDown(KeybindManager.Km.ml) || (x1 == -1 && y2 == 0))
        {
            GameManager.Instance.Click(0);
        }


        if (Input.GetKeyDown(KeybindManager.Km.tr) || (x > 0.1f && y > 0.1f))
        {
            GameManager.Instance.Click(4);
        }


        if (Input.GetKeyDown(KeybindManager.Km.bl) || (x < -0.1f && y < -0.1f))
        {
            GameManager.Instance.Click(2);
        }


        if (Input.GetKeyDown(KeybindManager.Km.br) || (x > 0.001f && y < -0.001f))
        {
            GameManager.Instance.Click(3);
        }


        if (Input.GetKeyDown(KeybindManager.Km.tl) || (x < -0.1f && y > 0.1f))
        {
            GameManager.Instance.Click(5);
        }
    }
}