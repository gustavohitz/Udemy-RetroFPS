using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Rigidbody2D rb2d;
    public float playerSpeed;

    private Vector2 _keyboardCommands;

    private void Update() {
        MovePlayer();
    }

    private void MovePlayer() {
        _keyboardCommands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMove = transform.up * -_keyboardCommands.x;
        Vector3 verticalMove = transform.right * _keyboardCommands.y;

        rb2d.velocity = (horizontalMove + verticalMove) * playerSpeed;
    }
   
}
