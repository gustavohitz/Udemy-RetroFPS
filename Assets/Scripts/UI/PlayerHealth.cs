using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    public void TakeDamage(int damageTaken) {
        if(GameManager.instance.playerIsAlive) {
            currentHealth -= damageTaken;

            if(currentHealth <= 0) {
                GameManager.instance.GameOver();
            }
        }
    }

}
