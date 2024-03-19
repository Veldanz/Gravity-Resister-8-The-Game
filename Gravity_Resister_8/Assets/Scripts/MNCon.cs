using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MNCon : MonoBehaviour
{
    public AudioSource PlayerSound;
     private void OnTriggerEnter2D (Collider2D collision) //Check the collision.
    {
        if (collision.gameObject.CompareTag("Player")) //If it is a player, do this.
        {
            PlayerSound.Play(); //Play sound.
        }
    }
}
