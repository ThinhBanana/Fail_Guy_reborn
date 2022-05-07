using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpringTrap : MonoBehaviour
{
    //public Rigidbody rigidBody;
    public bool isActive = false;
    public float force;
    private Rigidbody rigidBody;


    private void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        
    }


    private void OnCollisionEnter(Collision other) {
        if (other.collider.gameObject.tag == "Player")
        {
            if (!isActive)
            {
                rigidBody.AddForce(Vector3.up * force, ForceMode.Impulse);
                this.transform.Translate(Vector3.up * 10);
                isActive = true;
            }
            // while (isActive)
            // {
            //     if (this.transform.localPosition.y > 0)
            //     {
            //         this.gameObject.transform.Translate(Vector3.down);
            //     }
            //     else
            //         isActive = false;
            // }
        }
    }
        
    private void MoveDown()
    {
        if (this.transform.localPosition.y > 0)
                {
                    this.gameObject.transform.Translate(Vector3.down);
                }
                else
                    isActive = false;
    }
}
