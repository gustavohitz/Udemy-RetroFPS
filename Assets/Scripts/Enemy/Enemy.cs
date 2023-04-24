using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    public Transform[] walkingPoints;
    public int currentWalkingPoint;

    public bool isAlive;
    public bool canWalk;

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
                    currentWalkingPoint++;
                }

                if(currentWalkingPoint == walkingPoints.Length) {
                    currentWalkingPoint = 0;
                }
            }
        }
    }
    
}
