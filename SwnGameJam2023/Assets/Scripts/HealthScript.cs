using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Derived from Alan Thorn's Health Script
public class HealthScript : MonoBehaviour
{
    string parentedTag;
    public GameObject particals;
    [SerializeField]
    private float startingHealth; 
    private float maxHealth;
    public float healthPoints;
    [SerializeField] private HealthUI healthUI;
    private string objectTagToString;
    public bool invincible = false;
    public float iframes = 0.5f;
    private bool Enemy_Eliminated = false;
    Animate animateScript;
    //Called whenever a health change is needed
    IEnumerator iframeWaiter(float iframes)
    {
        yield return new WaitForSeconds(iframes);
    }
    public void UpdateHealth(float change)
    {
        if (invincible)return;  
        //Changes health
        healthPoints -= change;
        //Debug.Log("Damage done to: " + gameObject.ToString());
        healthPoints = Mathf.Clamp(healthPoints, 0f, maxHealth); //Makes sure health is in the correct range
        if (healthPoints <= 0f && Enemy_Eliminated == false)
        {
            Eliminate();
            Enemy_Eliminated = true;
        }
        //Debug.Log("got here updating health");
        //if (animateScript == null) return;
        //Debug.Log("made it past null check");

        //Animations
        if (objectTagToString == "Player")
        {
            invincible = true;
            //Debug.Log("Player calling");
            animateScript.DamageAnimation("playerBlink");
            Debug.Log("player blink call");
            healthUI.UpdateHearts(healthPoints);
            StartCoroutine(iframeWaiter(iframes));
            
            invincible = false;
        }
        /*
        else if (objectTagToString == "Enemy")
        {
            animateScript.DamageAnimation("EnemyBlink");
        }
        */
        //Death check
        

    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(startingHealth);
        maxHealth = startingHealth;
        healthPoints = startingHealth;
        parentedTag = gameObject.tag;
        animateScript = gameObject.GetComponent<Animate>();
        objectTagToString = parentedTag.ToString();
    }
    //Destroys or reloads scene depending on object being killed
    public void Eliminate()
    {
        //Debug.Log("Bye: " + objectTagToString);
        if (objectTagToString == "Enemy")
        {
            GameObject scoreCounter = GameObject.FindGameObjectsWithTag("Score counter")[0].gameObject;
            scoreCounter.GetComponent<ScoreCounter>().incrementScore();
            Instantiate(particals, transform.position, transform.rotation = Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        else if(objectTagToString == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
       
}
