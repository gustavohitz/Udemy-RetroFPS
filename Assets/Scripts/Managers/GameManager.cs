using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool playerIsAlive;
    public bool hasSilverKey;
    public bool hasGoldenKey;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _gameOverPanel;
    
    public bool isGamePaused;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Time.timeScale = 1f;

        playerIsAlive = true;
        hasSilverKey = false;
        hasGoldenKey = false;
        isGamePaused = false;
    }

    private void Update() {
        PushingKeyToPauseAndUnpauseGame();
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
        isGamePaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        isGamePaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void PushingKeyToPauseAndUnpauseGame() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(!isGamePaused) {
                PauseGame();
            }
            else {
                UnpauseGame();
            }
        }
    }

    public void GameOver() {
        _gameOverPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        playerIsAlive = false;
        FindObjectOfType<BgmManager>().PlayGameOverBGM();
        Debug.Log("Player was killed");
    }
    
}
