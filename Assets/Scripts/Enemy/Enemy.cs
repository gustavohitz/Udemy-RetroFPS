using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Movement")]
    public float enemySpeed;
    public Transform[] walkingPoints;
    public int currentWalkingPoint;

    [Header("Attack")]
    public float distanceToAttack;
    public float timeBetweenAttack;
    public Transform shotOrigin;
    public GameObject shotPrefab;

    [Header("Boolean Conditions to Move")]
    public bool isAlive;
    public bool canWalk;
    private bool enemyHasAttacked;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Time Conditions to Move")]
    public float timeBetweenWalkingPoints;
    public float currentTime;

    private void Start() {
        isAlive = true;
        canWalk = true;
        enemyHasAttacked = false;

        currentHealth = maxHealth;

        transform.position = walkingPoints[0].position;
    }

    private void Update() {
        MoveEnemy();
        CheckDistance();
    }

    private void MoveEnemy() {
        if(isAlive) {
            if(canWalk) {
                transform.position = Vector2.MoveTowards(transform.position, walkingPoints[currentWalkingPoint].position, enemySpeed * Time.deltaTime);

                if(transform.position.y == walkingPoints[currentWalkingPoint].position.y) {
                    WaitBeforeWalking();
                }

                if(currentWalkingPoint == walkingPoints.Length) {
                    currentWalkingPoint = 0;
                }
            }
        }
    }

    private void WaitBeforeWalking() {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0) {
            canWalk = true;
            currentWalkingPoint++;
            currentTime = timeBetweenWalkingPoints;
        }
    }

    private void CheckDistance() {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < distanceToAttack) {
            AttackPlayer();
        }
        else {
            canWalk = true;
        }
    }

    private void AttackPlayer() {
        if(!enemyHasAttacked) {
            canWalk = false;
            Instantiate(shotPrefab, shotOrigin.position, shotOrigin.rotation);
            enemyHasAttacked = true;
            Invoke(nameof(ResetEnemyAttack), timeBetweenAttack);
            //quando invocamos um método, falamos para a Unuty
            //de quanto em quanto tempo ele deve ser chamado.
        }
    }

    private void ResetEnemyAttack() {
        enemyHasAttacked = false;
    }

    public void TakeDamage(int damageTaken) {
        if(isAlive) {
            currentHealth -= damageTaken;

            if(currentHealth <= 0) {
                isAlive = false;
                canWalk = false;
                DefeatEnemy();
            }
        }
    }
    public void DefeatEnemy() {
        Destroy(this.gameObject);
    }
    
}
