using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Camera gameCamera;

    private void Update() {
        Shoot();
    }

    private void Shoot() {
        if(Input.GetButtonDown("Fire1")) {
            Ray ray = gameCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitPoint;
            //um raio é lançado no centro da tela. Abaixo, verificamos se atingiu algo.

            if(Physics.Raycast(ray, out hitPoint)) {
                Debug.Log("I'm looking at: " + hitPoint.transform.name);
                //a Unity pega o nome do gameobject que atingimos.
            }
            else {
                Debug.Log("I'm looking at nothing");
            }
        }
    }

}
