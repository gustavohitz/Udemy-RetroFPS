using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    public Transform[] walkingPoints;
    public int currentWalkingPoint;

    public bool isAlive;
    public bool canWalk;

    public float timeBetweenWalkingPoints;
    public float currentTime;

    private void Start() {
        isAlive = true;
        canWalk = true;

        transform.position = walkingPoints[0].position;
    }

    private void Update() {
        MoveEnemy();
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
    
}
