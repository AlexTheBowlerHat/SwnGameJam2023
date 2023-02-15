using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 KnockBackForce;
    public float KnockBackForceMultiplyer;
    private void OnCollisionEnter2D(Collider2D other){
        Debug.Log("OnTriggerEnter called");
        if(other.tag == "Player"){
            KnockBackForce = (other.transform.position - transform.position) * Time.deltaTime;
            transform.GetComponent<Rigidbody2D>().AddForce(KnockBackForce * KnockBackForceMultiplyer);
        }    
    }
}
