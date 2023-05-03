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
    private bool _isGamePaused;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Time.timeScale = 1f;

        playerIsAlive = true;
        hasSilverKey = false;
        hasGoldenKey = false;
        _isGamePaused = false;
    }

    private void Update() {
        PushingKeyToPauseAndUnpauseGame();
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
        _isGamePaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        _isGamePaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void PushingKeyToPauseAndUnpauseGame() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(!_isGamePaused) {
                PauseGame();
            }
            else {
                UnpauseGame();
            }
        }
    }

    public void GameOver() {
        playerIsAlive = false;
        FindObjectOfType<BgmManager>().PlayGameOverBGM();
        Debug.Log("Player was killed");
    }
    
}
