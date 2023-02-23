using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float KnockBackForceMultiplyer;
    public float EnemyDamage = 1;
    bool dealtDamage = false;
    public float enemyDamageCooldown = 0.5f;
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(enemyDamageCooldown);
    }

    //When collided, causes knockback and damage, puts enemy on cooldown
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag != "Player") return;
        gameObject.GetComponent<DefaltEnemyMovement>().ApplyKnockBack(KnockBackForceMultiplyer);
        HealthScript collidedHealthClass = other.GetComponent<HealthScript>();
        if (collidedHealthClass == null) return;

        if (dealtDamage) return;
        dealtDamage = true;
        collidedHealthClass.UpdateHealth(EnemyDamage);
        CoolDown();

        dealtDamage = false;
    }
}