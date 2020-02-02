using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI ;

    /*public void Start()
    {
        GameIsPaused = false;
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    // Start is called before the first frame update
    public void Resume()
    {
        PauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }



    // Update is called once per frame
    public void Restart()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene("Game");
    } 

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    
    
}
