using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public void ContinueGame() {
        GameManager.instance.UnpauseGame();
    }

    public void QuitGame() {
        Application.Quit();
    }
    
}
