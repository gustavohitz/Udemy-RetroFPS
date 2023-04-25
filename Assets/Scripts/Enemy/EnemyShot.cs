using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    public float shotSpeed;

    private void Update() {
        MoveEnemyShot();
    }

    private void MoveEnemyShot() {
        transform.Translate(Vector3.forward * shotSpeed * Time.deltaTime);
    }
    
}
