using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    private float lenght,starpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        cam = GameObject.Find("CM vcam1"); // Find the camera name "CM vcam1".
        starpos = transform.position.x; // Save the starting position of the object.
        lenght = GetComponent <SpriteRenderer>().bounds.size.x; // Get the length (width) of the image.
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1-parallaxEffect)); // Calculate the temporary position of the background object based on the camera's x-position and the parallax effect.
        float dist = (cam.transform.position.x * parallaxEffect); // Calculate the distance the background object should move based on the camera's x-position and the parallax effect
        transform.position = new Vector3 (starpos+dist,transform.position.y,transform.position.z); // Update the position of the background object by adding the distance to its current x-position.
        if(temp > starpos+lenght)// If the temporary position is greater than the current star position plus the length of the star field.
        {
            starpos += lenght; // Adjust the star position by adding the length of the star field.
        }
        if(temp < starpos-lenght) // If the temporary position is less than the current star position minus the length of the star field.
        {
            starpos -= lenght; // Adjust the star position by subtracting the length of the star field.
        }
    }
}
