using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    string tagThatFired;
    float projectileDamage;
    SFXControl audioReference;

    private void Start()
    {
        audioReference = GameObject.FindGameObjectsWithTag("Sound")[0].GetComponent<SFXControl>();
        Destroy(gameObject, 4f);
    }
    //Sets tag to stop projectile hitting itself
    public void SetFired(string passedTag, float passedDamage)
    {
        tagThatFired = passedTag;
        projectileDamage = passedDamage;
    }
    //Method for deleting and dealing damage
    private void ProjectileCleanup(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag != "Player" && collision.tag != "Enemy") return;
        HealthScript collidedHealthClass = collision.GetComponent<HealthScript>();
        if (collidedHealthClass == null || collidedHealthClass.invincible == true) return;
        audioReference.PlaySFX();
        StartCoroutine(collidedHealthClass.UpdateHealth(projectileDamage)); 
    }

    //Cleans up projectile once it hits an object, checks it isn't hitting its owner
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if(collision.tag == tagThatFired || collision.tag == "NotToBeCollided") return;
        ProjectileCleanup(collision);
    }
}
