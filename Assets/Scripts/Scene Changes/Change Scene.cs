using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string tutorialLevelScene;
    //public string firstLevelScene;
    public string mainMenuScene;
    public void OnTutorialButtonClicked()
    {
        SceneManager.LoadScene(tutorialLevelScene);
    }

    public void OnStartLevelButtonClicked()
    {
        //SceneManager.LoadScene(firstLevelScene);
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
