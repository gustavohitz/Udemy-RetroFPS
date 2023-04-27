using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    public float shotSpeed;

    [SerializeField]
    private int _maxDamageCaused;
    [SerializeField]
    private int _minDamageCaused;

    private void Update() {
        MoveEnemyShot();
    }

    private void MoveEnemyShot() {
        transform.Translate(Vector3.forward * shotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Random.Range(_minDamageCaused, _maxDamageCaused));
            //fiz assim para que o dano varie entre valores, que setei no editor.
        }

        Destroy(this.gameObject);
    }
    
}
