using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour {

    [SerializeField]
    private bool _isAmmoCollectable;
    [SerializeField]
    private bool _isHealthCollectable;
    [SerializeField]
    private bool _isSilverKeyCollectable;
    [SerializeField]
    private bool _isGoldenKeyCollectable;

    [SerializeField]
    private int _ammoAmountGiven;
    [SerializeField]
    private int _healthAmountGiven;

    [SerializeField]
    private int _minAmmoAmountPerItem;
    [SerializeField]
    private int _maxAmmoAmountPerItem;
    [SerializeField]
    private int _minHealthAmountPerItem;
    [SerializeField]
    private int _maxHealthAmountPerItem;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            if(_isAmmoCollectable) {
                other.gameObject.GetComponent<PlayerAttack>().IncreaseAmmo(Random.Range(_minAmmoAmountPerItem, _maxAmmoAmountPerItem));
                SfxManager.instance.PlayOnCollectingAmmoSFX();
            }
            if(_isHealthCollectable) {
                other.gameObject.GetComponent<PlayerHealth>().IncreaseHealth(Random.Range(_minHealthAmountPerItem, _maxHealthAmountPerItem));
                SfxManager.instance.PlayOnCollectingHealthSFX();
            }
            if(_isSilverKeyCollectable) {
                GameManager.instance.hasSilverKey = true;
                SfxManager.instance.PlayOnCollectingKeySFX();
            }
            if(_isGoldenKeyCollectable) {
                GameManager.instance.hasGoldenKey = true;
                SfxManager.instance.PlayOnCollectingKeySFX();
            }

            Destroy(this.gameObject);
        }
    }
    
}
