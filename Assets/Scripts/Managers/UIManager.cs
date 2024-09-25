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
    [SerializeField] GameObject UIPausePanel;
    [SerializeField] GameObject UIOptionsPanel;
    [SerializeField] bool isPause;
    [SerializeField] bool isOPtions;

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
        ResumeGame();
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
                UIOptionsPanel.SetActive(false);
                UIPausePanel.SetActive(true);
                isOPtions = isOPtions = false;
        }
    }
    public void UpdateUI()
    {
        lifeAmount();
        UpdateTexts();
    }
    public void OptionsManager()
    {
        if(isOPtions)
        {
            Debug.Log("options panel off");
            UIOptionsPanel.SetActive(false);
            UIPausePanel.SetActive(true);
            isOPtions = isOPtions = true;
        }
        else
        {
            Debug.Log("options panel on");
            UIOptionsPanel.SetActive(true);
            UIPausePanel.SetActive(false);
            isOPtions = isOPtions = false;
        }
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
    public bool IsPause
    {
        get
        {
            return isPause;
        }
    }
}