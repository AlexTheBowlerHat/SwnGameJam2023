using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaltEnemyMovement : MonoBehaviour
{
    public float speed;
    private float maxSpeed;
    public float health;
    public float turnSpeed;
    public Transform targetTransform;
    private Vector3 targetDirection;
    public bool beingKnockBacked = false;
    private Vector3 forceApplied;
    private float timer;

    // Sets the target of the enemy
    void Start()
    {
        targetTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        maxSpeed = speed;
    }

    Quaternion calculateRotationToPlayer(Transform targetTransform){
        // Calculates the Vector 2 distance between the target and player
        Vector3 dir = (targetTransform.position) - (transform.position);
        // Turns this Vector 2 into an angle
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        // Turns this angle into a rotation value
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    void Update()
    {
        // transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        Vector3 currentPos = transform.position;
        targetDirection = (targetTransform.position - currentPos).normalized;
        // Moves the enemy at a constant speed
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
        if (beingKnockBacked == true){
            transform.GetComponent<Rigidbody2D>().AddForce(-forceApplied * Time.deltaTime / 0.5f);
            timer += Time.deltaTime;
            if (timer >= 0.5f){
                beingKnockBacked = false;
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                speed = maxSpeed;
            }
        }
    }
    public void ApplyKnockBack(float KBMultiplyer){
        speed = 0;
        timer = 0;
        beingKnockBacked = true;
        Vector3 KBforce = Vector3.Normalize(-(targetTransform.position - transform.position));
        forceApplied = KBforce * KBMultiplyer;
        transform.GetComponent<Rigidbody2D>().AddForce(forceApplied);
    }
}