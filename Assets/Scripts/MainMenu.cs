using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level 1 Actual");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
