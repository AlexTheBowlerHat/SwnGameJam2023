using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXControl : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip shootSFX;
    public AudioClip[] HitSFXarray;
    bool SFXplaying;
  
    //Initialises sound reference
    void Start()
    {
        audioSrc = GameObject.FindGameObjectsWithTag("Sound")[0].GetComponent<AudioSource>();
        SFXplaying = false;
        //audioSrc.clip = sfx1;
    }

    public void PlaySFX()
    {
        //Todo, specific sound for death
        SFXplaying = true;
        //Picks random sound on hit
        int randomNumber = Random.Range(0,HitSFXarray.Length);
        //Debug.Log(randomNumber);
        audioSrc.clip = HitSFXarray[randomNumber];
        audioSrc.Play();
        SFXplaying = false;
    }
}
