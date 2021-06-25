using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public float level;
    public int isFinishL;

    // Start is called before the first frame update
    void Start()
    {
        isFinishL = PlayerPrefs.GetInt("level1", isFinishL);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("level1", isFinishL);

        if (level == 1 && GameplayManager.Instance.isFinish == true)
        {
            isFinishL = 1;
        }
        if (level == 2 && GameplayManager.Instance.isFinish == true)
        {
            isFinishL = 2;
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
            //SceneManager.LoadScene(3);
        }
    }
}
