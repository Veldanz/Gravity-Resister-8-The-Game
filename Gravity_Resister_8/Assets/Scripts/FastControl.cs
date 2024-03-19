using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastControl : MonoBehaviour
{
    public float rotateSpeed;
    public AudioSource PlayerSound;
    
    void Update()
    {
         transform.Rotate(0,-rotateSpeed,0,Space.World); //Make the sprite rotating.
    }
    private void OnTriggerEnter2D (Collider2D collision) //Chech the collision.
    {
        if (collision.gameObject.CompareTag("Player")) //If it hit player, do this.
        {
            PlayerSound.Play(); //Play sound that attached.
            Destroy(gameObject); //Destroy game object.
        }
    }
}
