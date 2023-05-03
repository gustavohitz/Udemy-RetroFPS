using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    [SerializeField]
    private string _sceneToLoad;

    public void LoadMainMenuScene() {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void QuitGame() {
        Application.Quit();
    }
   
}
