using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    // UI  variables
    [SerializeField] Image lifeImage;
    [SerializeField] TextMeshProUGUI killText;
    [SerializeField] TextMeshProUGUI healtsText;
    [SerializeField] GameObject PausePanel;
    [SerializeField] bool isPause;

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
        UpdateUI();
    }
        private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPause)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void UpdateUI()
    {
        Debug.Log("updateUI");
        lifeAmount();
        UpdateTexts();
    }
    public void PauseManager()
    {
        
    }
    
    public void DeathPanel()
    {
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
        PausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;
        PausePanel.SetActive(false);
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
        lifeImage.fillAmount = PlayerStats.instance.Life/PlayerStats.instance.MaxLife;
    }
    public void UpdateTexts()
    {
        killText.text = GameManager.instance.KillsAcount.ToString();
        healtsText.text = GameManager.instance.HealAcount.ToString();
    }
}