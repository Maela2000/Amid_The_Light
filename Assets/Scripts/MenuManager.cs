using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;


    public GameObject Commands;
    public GameObject levels;
    public GameObject unlockL2;
    public Transform level;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }

        if (level.GetComponent<Levels>().isFinishL >= 1)
        {
            unlockL2.SetActive(false);
        }
        if (level.GetComponent<Levels>().isFinishL == 0)
        {
            unlockL2.SetActive(true);
        }
    }

    public void OnClick_Start()
    {
        Commands.SetActive(true);
        StartCoroutine(Play());
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

    public void OnClick_Menu()
    {
        Commands.SetActive(false);
        levels.SetActive(false);
    }

    public void OnClick_Levels()
    {
        levels.SetActive(true);
    }
    public void OnClick_Level1()
    {
        Commands.SetActive(true);
        StartCoroutine(Play());
    }
    
    IEnumerator Play()
    {
        yield return new WaitForSeconds(7.5f);
        SceneManager.LoadScene(1);
    }
}
