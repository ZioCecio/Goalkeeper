using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour {
    [SerializeField] public TMP_Dropdown resolutionDropDown;
    [SerializeField]
    public TMP_Dropdown difficultyDP;
    Resolution[] ScreenResolutions;
    public float timeDifficult;

    void Start()
    {
        int currentResIndex = 0;
        ScreenResolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        difficultyDP.value = PlayerPrefs.GetInt("Difficulty");
        difficultyDP.RefreshShownValue();

        List<string> options = new List<string>();
        //PlayerPrefs.GetInt("Difficulty", 0);

        for (int i = 0; i < ScreenResolutions.Length; i++)
        {
            string option = ScreenResolutions[i].width + "x" + ScreenResolutions[i].height;
            options.Add(option);

            if(ScreenResolutions[i].width == Screen.currentResolution.width &&
                ScreenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool choice)
    {
        Screen.fullScreen = choice;
    }

    public void SetScreenResolution (int choice)
    {
        Resolution resolution = ScreenResolutions[choice];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetDifficult(int choice)
    {
        PlayerPrefs.SetInt("Difficulty", choice);
        difficultyDP.value = choice;
        difficultyDP.RefreshShownValue();

        if (choice == 0)
            timeDifficult = 1f;
        if (choice == 1)
            timeDifficult = .75f;
        if (choice == 2)
            timeDifficult = .5f;

        LevelManager.Instance.difficult = timeDifficult;
        
    }

}
