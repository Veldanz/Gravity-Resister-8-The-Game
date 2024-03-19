using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    public float rotateSpeed;
    public AudioSource PlayerSound;

    void Update()
    {
         transform.Rotate(0,-rotateSpeed,0,Space.World); //Make the sprite rotating.
    }
    private void OnTriggerEnter2D (Collider2D collision) //Check the collision.
    {
        if (collision.gameObject.CompareTag("Player")) //If it hits the player.
        {
            PlayerSound.Play(); //Play sound.
            Destroy(gameObject); //Destroy this game object.
        }
    }
}
