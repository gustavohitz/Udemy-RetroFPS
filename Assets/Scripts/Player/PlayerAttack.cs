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
    public int damageCausedByGun;

    private void Start() {
        ammoTxt.text = currentAmmo.ToString();
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

                    if(hitPoint.transform.gameObject.CompareTag("Enemy")) {
                        hitPoint.transform.gameObject.GetComponentInParent<Enemy>().TakeDamage(damageCausedByGun);
                    }
                }
                else {
                    Debug.Log("I'm looking at nothing");
                }

                currentAmmo --;
                ammoTxt.text = currentAmmo.ToString();
                gunAnimator.SetTrigger("Gun Firing");
            }
            else {
                Debug.Log("No ammo");
            }
        }
    }

    public void IncreaseAmmo(int ammoReceived) {
        if(currentAmmo + ammoReceived < maxAmmo) {
            currentAmmo += ammoReceived;
        }
        else {
            currentAmmo = maxAmmo;
        }

        ammoTxt.text = currentAmmo.ToString();
    }

}
