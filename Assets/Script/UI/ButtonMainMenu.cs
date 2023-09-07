using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public void startGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame() 
    {
        Application.Quit();
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadScenWin1()
    {
        SceneManager.LoadScene(3);
    }

    public void loadScenWin2() 
    {
        SceneManager.LoadScene(2);
    }
}
