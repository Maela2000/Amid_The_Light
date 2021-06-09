using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject unlockL2;
    public GameObject unlockL3;
    public float level;
    public int isFinishL;

    // Start is called before the first frame update
    void Start()
    {
        isFinishL = PlayerPrefs.GetInt("level", isFinishL);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("level", isFinishL);

        if (level == 1 && GameplayManager.Instance.isFinish == true)
        {
            isFinishL = 1;
        }
        if (level == 2 && GameplayManager.Instance.isFinish == true)
        {
            isFinishL = 2;
        }
        if(isFinishL>=1)
        {
            unlockL2.SetActive(false);
        }
        if (isFinishL >= 2)
        {
            unlockL3.SetActive(false);
        }
        if (isFinishL == 0)
        {
            unlockL2.SetActive(true);
        }
        if (isFinishL <= 1)
        {
            unlockL3.SetActive(true);
        }
    }

    public void OnClick_Level2()
    {
        if (isFinishL >= 1)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void OnClick_Level3()
    {
        if (isFinishL >= 2)
        {
            SceneManager.LoadScene(3);
        }
    }
}
