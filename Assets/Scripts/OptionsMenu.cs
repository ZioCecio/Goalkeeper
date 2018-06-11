using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour {

    //public AudioMixer MasterMixer;
    [SerializeField]public TMP_Dropdown resolutionDropDown;
    Resolution[] ScreenResolutions;

    void Start()
    {
        //MasterMixer.SetFloat("MasterVolume", 20);
        int currentResIndex = 0;
        ScreenResolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        
        for(int i = 0; i < ScreenResolutions.Length; i++)
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

    /*public void SetVolume(float volume)
    {
        MasterMixer.SetFloat("MasterVolume", volume);
    }*/

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

}
