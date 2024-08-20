using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnTutorialButtonClicked()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void OnStartLevelButtonClicked()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
