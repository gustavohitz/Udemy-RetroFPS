using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    [SerializeField]
    private Animator _doorAnimator;

    [SerializeField]
    private Collider2D _doorCollider;

    [SerializeField]
    private bool _isRegularDoor;
    [SerializeField]
    private bool _isSilverKeyDoor;
    [SerializeField]
    private bool _isGoldenKeyDoor;

    private bool _isDoorClosed;

    private void Start() {
        _isDoorClosed = true;
    }

    private void OpenDoor() {
        _doorAnimator.SetTrigger("Door Open");
        _isDoorClosed = false;
        StartCoroutine(DeactivateDoorCollider());
    }

    IEnumerator DeactivateDoorCollider() {
        yield return new WaitForSeconds(1);
        _doorCollider.enabled = false;
    }

    private void CloseDoor() {
        _doorAnimator.SetTrigger("Door Close");
        _isDoorClosed = true;
        _doorCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            if(_isDoorClosed) {
                if(_isRegularDoor) {
                    OpenDoor();
                }

                if(_isSilverKeyDoor) {
                    if(GameManager.instance.hasSilverKey) {
                        OpenDoor();
                    }
                }

                if(_isGoldenKeyDoor) {
                    if(GameManager.instance.hasGoldenKey) {
                        OpenDoor();
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            if(!_isDoorClosed) {
                CloseDoor();
            }
        }
    }
    
}
