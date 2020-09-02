using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject AboutUsPanel;
    public GameObject SettingsPanel;
    public GameObject PrivacyPanel;
    public Slider slider;
    // Start is called before the first frame update

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            slider.value = 0.4f;
            AdjustVolume(0.4f);
        }
    }

    public void MainMenuMethod()
    {
        MainMenuPanel.SetActive(true);
        AboutUsPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        PrivacyPanel.SetActive(false);
    }

    public void AboutMethod()
    {
        MainMenuPanel.SetActive(false);
        AboutUsPanel.SetActive(true);
    }

    public void SettingsMethod()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void PrivacyMethod()
    {
        MainMenuPanel.SetActive(false);
        PrivacyPanel.SetActive(true);
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/Terminator9530");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/Vaibhav93959245");
    }

    public void OpenLinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/vaibhav-shukla-078ba419b/");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/vaibhav.shukla.79230/");
    }

    public void AdjustVolume(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
    }
}
