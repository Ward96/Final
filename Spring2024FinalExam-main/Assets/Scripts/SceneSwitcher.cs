using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Exit");
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
