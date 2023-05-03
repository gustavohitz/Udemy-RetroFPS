using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour {

    public static SfxManager instance;

    [SerializeField]
    private AudioSource _enemyAttackSFX;
    [SerializeField]
    private AudioSource _playerAttackSF, _onCollectingKeySFX, _enemyDamageSFX, _playerDamageSFX, _onDefeatingEnemySFX, _onCollectingAmmoSFX, _noAmmoSFX, _onCollectingHealthSFX;

    private void Awake() {
        instance = this;
    }

    public void PlayEnemyAttackSFX() {
        _enemyAttackSFX.Play();
    }

    public void PlayPlayerAttackSFX() {
        _playerAttackSF.Play();
    }

    public void PlayOnCollectingKeySFX() {
        _onCollectingKeySFX.Play();
    }

    public void PlayEnemyDamageSFX() {
        _enemyDamageSFX.Play();
    }

    public void PlayPlayerDamageSFX() {
        _playerDamageSFX.Play();
    }

    public void PlayOnDefeatingEnemySFX() {
        _onDefeatingEnemySFX.Play();
    }

    public void PlayOnCollectingAmmoSFX() {
        _onCollectingAmmoSFX.Play();
    }

    public void PlayNoAmmoSFX() {
        _noAmmoSFX.Play();
    }

    public void PlayOnCollectingHealthSFX() {
        _onCollectingHealthSFX.Play();
    }
   
}
