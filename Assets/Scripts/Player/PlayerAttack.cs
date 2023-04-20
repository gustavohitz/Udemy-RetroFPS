using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Camera gameCamera;
    public GameObject bulletImpactPrefab;
    public Animator gunAnimator;
    public Text ammoTxt;
    public int maxAmmo;
    public int currentAmmo;

    private void Start() {
        ammoTxt.text = "AMMO\n" + currentAmmo;
    }

    private void Update() {
        Shoot();
    }

    private void Shoot() {
        if(Input.GetButtonDown("Fire1")) {
            if(currentAmmo > 0) {
                Ray ray = gameCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hitPoint;
                //um raio é lançado no centro da tela. Abaixo, verificamos se atingiu algo.

                if(Physics.Raycast(ray, out hitPoint)) {
                    Instantiate(bulletImpactPrefab, hitPoint.point, hitPoint.transform.rotation);
                    Debug.Log("I'm looking at: " + hitPoint.transform.name);
                    //a Unity pega o nome do gameobject que atingimos.
                }
                else {
                    Debug.Log("I'm looking at nothing");
                }

                currentAmmo --;
                ammoTxt.text = "AMMO\n" + currentAmmo;
                gunAnimator.SetTrigger("Gun Firing");
            }
            else {
                Debug.Log("No ammo");
            }
        }
    }

}
