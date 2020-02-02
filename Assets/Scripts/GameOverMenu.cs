using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
   
    public void Continue()
    {
        SceneManager.LoadScene("Main");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

}
