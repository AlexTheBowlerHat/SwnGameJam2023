using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    string tagThatFired;
    float projectileDamage;
    public AudioSource audioSrc;
    public AudioClip sfx1, sfx2;

    private void Start()
    {
        audioSrc = GameObject.FindGameObjectsWithTag("Sound")[0].GetComponent<AudioSource>();
        Destroy(gameObject, 4f);
        audioSrc.clip = sfx1;
    }
    //Sets tag to stop projectile hitting itself
    public void SetFired(string passedTag, float passedDamage)
    {
        tagThatFired = passedTag;
        projectileDamage = passedDamage;
    }
    private void ProjectileCleanup(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag == "Player"|| collision.tag == "Enemy")
        {
            HealthScript collidedHealthClass = collision.GetComponent<HealthScript>();
            if (collidedHealthClass == null) return;
            if (!collidedHealthClass.invincible)
            {
                if (Random.Range(0,1) == 0)
                {
                    audioSrc.clip = sfx1;
                }
                else
                {
                    audioSrc.clip = sfx2;
                }
                audioSrc.Play();
              collidedHealthClass.UpdateHealth(projectileDamage); 
            }
        }

    }

    //Cleans up projectile once it hits an object, checks it isn't hitting its owner
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if(collision.tag != tagThatFired && collision.tag != "NotToBeCollided") 
        {
            ProjectileCleanup(collision);
        }
    }
}
