using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{ public float Movement_Speed;
    public bool W_Pressed;
    public bool A_Pressed;
    public bool S_Pressed;
    public bool D_Pressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (Input.GetKeyDown(KeyCode.W))
        {
            W_Pressed = true;
        } 
    if(Input.GetKeyUp(KeyCode.W))
        {
            W_Pressed = false;
        }
    if (W_Pressed==true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Movement_Speed, transform.position.z);
        }

    if (Input.GetKeyDown(KeyCode.A))
        {
            A_Pressed = true;
        } 
    if(Input.GetKeyUp(KeyCode.A))
        {
            A_Pressed = false;
        }
    if (A_Pressed==true)
        {
            transform.position = new Vector3(transform.position.x - Movement_Speed, transform.position.y, transform.position.z);
        }
    
    if (Input.GetKeyDown(KeyCode.S))
        {
            S_Pressed = true;
        }
    if (Input.GetKeyUp(KeyCode.S))
        {
            S_Pressed = false;
        }
    if (S_Pressed == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Movement_Speed, transform.position.z);
        }

    if (Input.GetKeyDown(KeyCode.D))
        {
            D_Pressed = true;
        }
    if (Input.GetKeyUp(KeyCode.D))
        {
            D_Pressed = false;
        }
    if (D_Pressed == true)
        {
            transform.position = new Vector3(transform.position.x + Movement_Speed, transform.position.y, transform.position.z);
        }
    }
    
}