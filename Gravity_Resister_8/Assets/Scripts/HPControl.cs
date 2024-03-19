using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControl : MonoBehaviour
{
    public float rotateSpeed;
    public AudioSource PlayerSound;
    private void OnTriggerEnter2D (Collider2D collision) //Check the collision.
    {
        if (collision.gameObject.CompareTag("Player")) //If it hits player, do this.
        {
            PlayerSound.Play(); //Play sound that attached
            Destroy(gameObject); //Destroy this game object.
        }
    }
}
