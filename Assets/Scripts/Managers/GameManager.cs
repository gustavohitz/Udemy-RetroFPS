using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool playerIsAlive;
    public bool hasSilverKey;
    public bool hasGoldenKey;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        playerIsAlive = true;
        hasSilverKey = false;
        hasGoldenKey = false;
    }

    public void GameOver() {
        playerIsAlive = false;
        FindObjectOfType<BgmManager>().PlayGameOverBGM();
        Debug.Log("Player was killed");
    }
    
}
