using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public AudioClip gameOverAudio;
    public AudioClip backgroundMusic;
    public AudioClip gamePlayAudio;
    public int beatScore = 10;
    public GameObject gameWin;
    public GameObject gameOver;
    bool isGameWin = false;
    bool isGameOver = false;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            gameObject.AddComponent<AudioSource>();
            PlayAudio(gamePlayAudio, true);
        }
        else
        {
            gameObject.AddComponent<AudioSource>();
            PlayAudio(backgroundMusic, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        if (isGameWin || isGameOver)
        {
            return;
        }

        if(player != null)
        {
            if (player.GetComponent<playerstats>().health <= 0)
            {
                gameOver.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                isGameWin = true;
                player.SetActive(false);
                Instantiate(camera);
                PlayAudio(gameOverAudio, false);
                StartCoroutine(PlayBackgroundMusic());
            }
        }

        if (player != null)
        {
            if (player.GetComponent<playerstats>().score > beatScore)
            {
                gameWin.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                isGameOver = true;
                player.SetActive(false);
                PlayAudio(backgroundMusic, true);
                Instantiate(camera);
            }
        }
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAudio(AudioClip audioClip,bool loop)
    {
        AudioSource audio = GetComponent<AudioSource>();
       
        audio.clip = audioClip;
        audio.playOnAwake = false;
        audio.loop = loop;
        Debug.Log("Audio : " + audio + " " + "Audio Clip : " + audio.clip);
        audio.Play();
    }

    IEnumerator PlayBackgroundMusic()
    {
        yield return new WaitForSeconds(2f);
        PlayAudio(backgroundMusic, true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
