using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSomeTime : MonoBehaviour {

    [SerializeField]
    private float _timeToDestroyObject;

    private void Start() {
        Destroy(this.gameObject, _timeToDestroyObject);
    }
    
}
