using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // Restart same scene.
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit.
            Application.Quit();
        }
    }
}
