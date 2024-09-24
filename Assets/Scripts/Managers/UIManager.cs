using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public class UIManager : MonoBehaviour
{
    // UI  variables
    [SerializeField] Image lifeImage;

    public static UIManager instance;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy( this);
        }    
    }

    private void Start() 
    {
        Time.timeScale = 1;
    }
    public void UpdateUI()
    {
        Debug.Log("updateUI");
        lifeAmount();
    }
    public void PauseManager()
    {
        
    }   
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
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
    
    public void LoseGame()
    {
        Time.timeScale = 0;
    }

    public void lifeAmount()
    {
        lifeImage.fillAmount = PlayerStats.instance.Life/100;
    }
}