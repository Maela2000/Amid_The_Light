using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    #region variable
    public static GameplayManager Instance;

    /*public GameObject Player;
    public GameObject panelGameOver;
    public GameObject pauseTxt;
    public GameObject panelWin;
    public GameObject Boss;*/

    public float levier;
    public float max;
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


    #region Update
    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

       /* if (Input.GetKey(KeyCode.X))
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            pauseTxt.SetActive(true);

        }

        if (Input.GetKey(KeyCode.W))
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pauseTxt.SetActive(false);
        }*/

        if(levier >= max)
        {
            //ShowWin();
        }
        /*if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }*/
    }
    #endregion

    /*#region function

    public void ShowGameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWin()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    #endregion*/
}
