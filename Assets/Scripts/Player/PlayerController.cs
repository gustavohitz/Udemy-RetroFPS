using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Rigidbody2D rb2d;
    public float playerSpeed;
    public float mouseSensitivity;

    private Vector2 _keyboardCommands;
    private Vector2 _mouseMovement;

    private void Update() {
        MovePlayer();
        RotateCamera();
    }

    private void MovePlayer() {
        _keyboardCommands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMove = transform.up * - _keyboardCommands.x;
        Vector3 verticalMove = transform.right * _keyboardCommands.y;

        rb2d.velocity = (horizontalMove + verticalMove) * playerSpeed;
    }

    private void RotateCamera() {
        _mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y"));

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - _mouseMovement.x);
    }
   
}
