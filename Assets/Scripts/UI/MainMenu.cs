using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private string _levelName;

    private void Start() {
        Time.timeScale = 1f;
    }

    public void StartGame() {
        SceneManager.LoadScene(_levelName);
    }

    public void QuitGame() {
        Application.Quit();
    }
    
}
