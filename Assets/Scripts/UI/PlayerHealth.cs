using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _currentHealth;
    [SerializeField]
    private Text _healthTxt;

    private void Start() {
        _currentHealth = _maxHealth;
        _healthTxt.text = _currentHealth.ToString();
    }

    public void TakeDamage(int damageTaken) {
        if(GameManager.instance.playerIsAlive) {
            _currentHealth -= damageTaken;
            SfxManager.instance.PlayPlayerDamageSFX();
            _healthTxt.text = _currentHealth.ToString();

            if(_currentHealth <= 0) {
                GameManager.instance.GameOver();
            }
        }
    }
    public void IncreaseHealth(int healthReceived) {
        if(_currentHealth + healthReceived < _maxHealth) {
            _currentHealth += healthReceived;
        }
        else {
            _currentHealth = _maxHealth;
        }

        _healthTxt.text = _currentHealth.ToString();
    }

}
