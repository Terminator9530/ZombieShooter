using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject AboutUsPanel;
    public GameObject SettingsPanel;
    public GameObject PrivacyPanel;
    public GameObject ControlsPanel;
    public GameObject PauseMenuPanel;
    public Slider slider;
    // Start is called before the first frame update

    private void Start()
    {
        if(AboutUsPanel != null)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

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
        ControlsPanel.SetActive(false);
    }

    public void AboutMethod()
    {
        MainMenuPanel.SetActive(false);
        AboutUsPanel.SetActive(true);
    }

    public void SettingsMethod()
    {
        if (MainMenuPanel != null)
            MainMenuPanel.SetActive(false);
        else
            PauseMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void PrivacyMethod()
    {
        MainMenuPanel.SetActive(false);
        PrivacyPanel.SetActive(true);
    }

    public void ControlMethod()
    {
        MainMenuPanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void OpenGitHub(string name)
    {
        Application.OpenURL("https://github.com/" + name);
    }

    public void OpenTwitter(string name)
    {
        Application.OpenURL("https://twitter.com/" + name);
    }

    public void OpenLinkedIn(string name)
    {
        Application.OpenURL("https://www.linkedin.com/in/" + name);
    }

    public void OpenFacebook(string name)
    {
        Application.OpenURL("https://www.facebook.com/" + name);
    }

    public void AdjustVolume(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseMenuMethod()
    {
        PauseMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
}
