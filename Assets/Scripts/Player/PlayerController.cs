using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public Rigidbody2D rb2d;
    public Animator gunPanelAnimator;

    public float playerSpeed;
    public float mouseSensitivity;

    private Vector2 _keyboardCommands;
    private Vector2 _mouseMovement;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        MovePlayer();
        RotateCamera();
    }

    private void MovePlayer() {
        _keyboardCommands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMove = transform.up * - _keyboardCommands.x;
        Vector3 verticalMove = transform.right * _keyboardCommands.y;

        rb2d.velocity = (horizontalMove + verticalMove) * playerSpeed;

        if(rb2d.velocity.magnitude == 0) {
            gunPanelAnimator.Play("ANM_PlayerIdle");
        }
        else {
            gunPanelAnimator.Play("ANM_PlayerWalking");
        }
    }

    private void RotateCamera() {
        _mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y"));

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - _mouseMovement.x);
    }
   
}
