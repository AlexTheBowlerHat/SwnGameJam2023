using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    bool hasFired = false;
    [SerializeField] float projectileDamage;
    public int bulletsPerShot;
    public float maxSpread;

    //Coroutine that fires bullet with a cooldown
    public IEnumerator Shoot(Vector2 lookVector, float cooldown, float projectileForce, string firedTag, Transform firePoint, bool holdAccessibility)
    {
        if (!hasFired)
        {
            hasFired = true;
            shootShotgun(lookVector, maxSpread, firePoint, firedTag, projectileForce);
            //Fire(lookVector, firedTag, projectileForce, firePoint);
            yield return new WaitForSeconds(cooldown);
            hasFired = false;
        }
        yield break;
    }
   
   //Creates a projectile and fires it from the weapon, also passes the tag of object that fired it
    public void Fire(Vector2 lookVector, string firedTag, float projectileForce, Transform firePoint)
    {
        Vector2 projectileDirection = (projectileForce * lookVector);
        /*
        Debug.Log(firedTag + " CALLED FIRE()");
        Debug.Log("FORCE FIRED IS: " + projectileForce * lookVector);
        Debug.Log("MAGNITUDE IS: " + (projectileForce * lookVector).magnitude);
        */
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.tag = "NotToBeCollided";
        projectile.GetComponent<ProjectileBehavior>().SetFired(firedTag, projectileDamage);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection;
    }

    public void shootShotgun(Vector2 lookdirection, float maxSpread, Transform firepoint, string firedTag, float projectileForce){
        for(int i = 0; i < bulletsPerShot; i++){
            GameObject newBullet = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
            newBullet.GetComponent<ProjectileBehavior>().SetFired(firedTag, projectileDamage);

            Vector2 lookDirectionOffset = new Vector2(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread));
            Vector2 projectileDirection = (lookdirection + lookDirectionOffset).normalized;
            newBullet.GetComponent<Rigidbody2D>().velocity = projectileDirection * projectileForce;
        }
    }
}
