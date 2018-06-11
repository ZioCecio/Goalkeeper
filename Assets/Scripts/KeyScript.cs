using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyScript : MonoBehaviour
{

    Transform menuPanel;
    Event keyEvent;
    TMP_Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

    // Use this for initialization
    void Start()
    {

        menuPanel = transform.Find("KeysPanel");
        //menuPanel.gameObject.SetActive(false);
        waitingForKey = false;

        for (int i = 0; i < 18; i++)
        {
            //Debug.Log(menuPanel.GetChild(i).name);
            switch (menuPanel.GetChild(i).name)
            {
                case "TopLeftKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.tl.ToString();
                    break;
                case "MiddleLeftKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.ml.ToString();
                    break;
                case "BottomLeftKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.bl.ToString();
                    break;
                case "TopCenterKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.tc.ToString();
                    break;
                case "BottomCenterKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.bc.ToString();
                    break;
                case "TopRightKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.tr.ToString();
                    break;
                case "MiddleRightKey":
                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.mr.ToString();
                    break;
                case "BottomRightKey":

                    menuPanel.GetChild(i).GetComponentInChildren<TMP_Text>().text = KeybindManager.Km.br.ToString();
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }


    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(TMP_Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey();

        switch (keyName)
        {
            case "tl":
                KeybindManager.Km.tl = newKey;
                buttonText.text = KeybindManager.Km.tl.ToString();
                PlayerPrefs.SetString("topLeftKey", KeybindManager.Km.tl.ToString());
                break;
            case "ml":
                KeybindManager.Km.ml = newKey;
                buttonText.text = KeybindManager.Km.ml.ToString();
                PlayerPrefs.SetString("middleLeftKey", KeybindManager.Km.ml.ToString());
                break;
            case "bl":
                KeybindManager.Km.bl = newKey;
                buttonText.text = KeybindManager.Km.bl.ToString();
                PlayerPrefs.SetString("bottomLeftKey", KeybindManager.Km.bl.ToString());
                break;
            case "tc":
                KeybindManager.Km.tc = newKey;
                buttonText.text = KeybindManager.Km.tc.ToString();
                PlayerPrefs.SetString("topCenterKey", KeybindManager.Km.tc.ToString());
                break;
            case "bc":
                KeybindManager.Km.bc = newKey;
                buttonText.text = KeybindManager.Km.bc.ToString();
                PlayerPrefs.SetString("bottomCenterKey", KeybindManager.Km.bc.ToString());
                break;
            case "tr":
                KeybindManager.Km.tr = newKey;
                buttonText.text = KeybindManager.Km.tr.ToString();
                PlayerPrefs.SetString("topLeftKey", KeybindManager.Km.tr.ToString());
                break;
            case "mr":
                KeybindManager.Km.mr = newKey;
                buttonText.text = KeybindManager.Km.mr.ToString();
                PlayerPrefs.SetString("middleLeftKey", KeybindManager.Km.mr.ToString());
                break;
            case "br":
                KeybindManager.Km.br = newKey;
                buttonText.text = KeybindManager.Km.br.ToString();
                PlayerPrefs.SetString("bottomLeftKey", KeybindManager.Km.br.ToString());
                break;
        }
        yield return null;
    }
}
