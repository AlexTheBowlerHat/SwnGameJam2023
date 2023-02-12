using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaltEnemyMovement : MonoBehaviour
{
    public float speed;
    public float health;
    public float turnSpeed;
    public Transform targetTransform;

    // Sets the target of the enemy
    void Start()
    {
        targetTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
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
        Quaternion rotation = calculateRotationToPlayer(targetTransform);
        // Rotates the enemy to the target rotation 
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        // Moves the enemy at a constant speed
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }
    /*
    public void recoil(float recoil)
    {
       this.GetComponent<Rigidbody2D>().AddForce((targetTransform.position - transform.GetChild(0).transform.GetChild(0).position) * recoil * -Time.deltaTime);
    }
    */
    public void takeDamage(float damage)
    {
        // Subtracts damage from health
        health -= damage;
        // If the player is dead, kill it
         if (health <= 0)
         {
            Destroy(this.gameObject, 0.0f);
         }
    }
}