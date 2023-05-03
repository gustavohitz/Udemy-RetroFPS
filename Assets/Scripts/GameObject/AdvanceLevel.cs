using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceLevel : MonoBehaviour {

    [SerializeField]
    private string _sceneToLoad;
    [SerializeField]
    private Animator _transitionAnimator;

    public float timeToWaitToLoad;

    IEnumerator LoadNewLevel() {
        _transitionAnimator.Play("ANM_TransitionToBlack");

        yield return new WaitForSeconds(timeToWaitToLoad);

        SceneManager.LoadScene(_sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            StartCoroutine(LoadNewLevel());
        }
    }
   
}
