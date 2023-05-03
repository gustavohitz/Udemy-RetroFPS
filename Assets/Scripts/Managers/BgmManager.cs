using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {

    [SerializeField]
    private AudioSource _levelBGM, _gameOverBGM;

    private void Start() {
        PlayLevelBGM();
    }

    public void PlayLevelBGM() {
        _levelBGM.Play();
    }

    public void PlayGameOverBGM() {
        _levelBGM.Stop();
        _gameOverBGM.Play();
    }
    
}
