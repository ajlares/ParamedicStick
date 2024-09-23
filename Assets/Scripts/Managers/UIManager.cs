using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    private void Start() 
    {
                Time.timeScale = 1;
    }
    private void UpdateText()
    {

    }
    public void PauseManager()
    {
        
    }   
    public void PauseGame()
    {

    }
    public void ResumeGame()
    {

    }
    public void OptionsPanel()
    {

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void quitGame()
    {
        Application.Quit ();
    }
}