using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public bool gamePaused = false;
    public bool gameOver = false;

    public Text pauseText;

    public GameObject pauseScreen;

    AudioSource pauseAudio;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        pauseText = GameObject.Find("Pause Text").GetComponent<Text>();

        pauseScreen.SetActive(false);

        pauseAudio = gameObject.AddComponent<AudioSource>();
        pauseAudio.clip = (AudioClip)Resources.Load("Audio/pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameOver == false)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;

        if(gamePaused)
        {
            pauseAudio.Play();

            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
