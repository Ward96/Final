using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Canvas pauseCanvas;
    private bool isPaused = false;


    // Start is called before the first frame update
    void Start() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyDetection();
    }
    public void PauseTheGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseCanvas.gameObject.SetActive(true); 
    }
    public void ResumeTheGame() 
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void KeyDetection()//detects the p key
    {
        if (Input.GetKeyDown(KeyCode.P)) // P key pauses AND resumes
        {
            if (isPaused)
            {
                ResumeTheGame();
            }
            else
            {
                PauseTheGame();
            }
        }
    }
}
