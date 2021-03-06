using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    #region variable
    public static GameplayManager Instance;
    public static bool gameIsPaused;

    public GameObject player;
    public GameObject panelGameOver;
    public GameObject pauseTxt;
    public GameObject panelWin;
    public GameObject dashBar;
    public GameObject shadow;
    public GameObject Commands;
    public bool isFinish=false;

    public float levier;
    public bool coreDestroy;
    public bool bossAtt;
    public bool switchBoss = false;
    public float coreDie;
    //public float max;

    #endregion


    #region Awake
    void Awake()
    {
        if (Instance == null)
        { Instance = this; }
        else if (Instance != null)
        { Destroy(gameObject); }
    }
    #endregion

    public void Start()
    {
        Time.timeScale = 1;
    }


    #region Update
    public void Update()
    {
        if (coreDie >= 3)
        {
            StartCoroutine("stopAtt");
            ShowWin();
        }
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 1;
            pauseTxt.SetActive(false);
            AudioListener.pause = false;
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        if(player == null)
        {
            ShowGameOver();
        }

        /*if(player.GetComponent<PlayerMove>().isDash==true && isFinish == false)
        {
            dashBar.SetActive(true);
        }
        if (player.GetComponent<PlayerMove>().isDash == false)
        {
            dashBar.SetActive(false);
        }*/

        if (player.GetComponent<PlayerMove>().isShadowMode == true && isFinish == false)
        {
            shadow.SetActive(true);
        }
        if (player.GetComponent<PlayerMove>().isShadowMode == false)
        {
            shadow.SetActive(false);
        }
    }
    #endregion
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseTxt.SetActive(true);
            shadow.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            pauseTxt.SetActive(false);
        }
    }
   
    #region function

    public void ShowGameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
        dashBar.SetActive(false);
        shadow.SetActive(false);
    }

    public void ShowWin()
    {
        dashBar.SetActive(false);
        shadow.SetActive(false);
        panelWin.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClick_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClick_Reprendre()
    {
        Time.timeScale = 1;
        pauseTxt.SetActive(false);
        AudioListener.pause = false;
    }

    public void OnClick_Continuer()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClick_Continuer2()
    {
        SceneManager.LoadScene(3);
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClick_Retry2()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClick_Retry3()
    {
        SceneManager.LoadScene(3);
    }

    public void OnClick_Commands()
    {
        Commands.SetActive(true);
    }

    public void OnClick_Pause()
    {
        Commands.SetActive(false);
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }
    #endregion
}
