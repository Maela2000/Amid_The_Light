using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;


    public GameObject Commands;
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
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

    public void OnClick_Commands()
    {
        Commands.SetActive(true);
    }

    public void OnClick_Menu()
    {
        Commands.SetActive(false);
    }
}
