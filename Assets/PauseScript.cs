using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool gamePaused = false;

    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;

        if(gamePaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }
}
