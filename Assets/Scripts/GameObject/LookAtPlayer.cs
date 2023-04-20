using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    private void Update() {
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
    }
   
}
