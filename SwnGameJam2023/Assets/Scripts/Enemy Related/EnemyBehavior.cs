using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float KnockBackForceMultiplyer;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            gameObject.GetComponent<DefaltEnemyMovement>().ApplyKnockBack(KnockBackForceMultiplyer);
        }    
    }
}