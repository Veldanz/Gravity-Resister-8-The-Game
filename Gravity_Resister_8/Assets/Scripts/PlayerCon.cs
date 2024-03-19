using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCon : MonoBehaviour
{
    public  int PlayerAct;
    private Animator anim;
    public float jumpSpeed = 10000f;
    float PlayerInput;
    int speed = 500;
    public int countHP = 100;
    public int countScore = 0;
    public Text showHP;
    public Text showScore;
    private Rigidbody2D player;

    private void Awake() //Call when open this game.
    {
        anim = GetComponent <Animator>(); //Get the animation component of the player.
        player = GetComponent <Rigidbody2D>(); //Get the rigidbody2d component of the player
    }

    private void FixedUpdate() //Call every frame while the game is running (60 times per second).
    {
        PlayerWalk(); //Call function to make the character walk.
    }
    void PlayerWalk() //Create a new function called "PlayerWalk".
    {
        anim.SetInteger("PlayerAct",PlayerAct); //Set the integer value of "PlayerAct" in the Animation window.
    }
    private void Update()
    {
        showHP.text = countHP.ToString(); //Convert integer HP into string and display on UI text.
        showScore.text = countScore.ToString(); //Convert integer score into string and display on UI text.
        PlayerInput = Input.GetAxis("Horizontal")*speed*Time.deltaTime; //Get input from horizontal axis.
        transform.Translate(PlayerInput,0,0); //Make the player sprits transforms according to the input.
        if(PlayerInput == 0) //If the player input nothing.
        {
            PlayerAct = 0; //PlayerAct will be equal to 0.
        }
        if(PlayerInput > 0) //If the player input move key.
        {
            PlayerAct = 1; //Player animation will be equal to 1;
            ChangeDirection(1); //Make the player sprite turn right.
        }
        if(PlayerInput < 0) //If player input move key.
        {
            PlayerAct = 1; //Player act will be equal to 1;
            ChangeDirection(-1); //But this time will turn left.
        }
        if(Input.GetButtonDown("Jump")) //If player input space bar.
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed); //Player sprite will be jump to the air.
        }
        if(countHP <= 0) //If player HP is 0 or less then.
        {
            PlayerAct = 5; //Do a dead animation.
            Destroy(gameObject); //Destroy player object.
            SceneManager.LoadScene("GameEnd"); //And then load scene name "GameEnd".
        }
    }
        void ChangeDirection (int direction) //Create ChangeDirection function.
    {
        Vector3 tempScale = transform.localScale; //Set temporary variable for scale.
        tempScale.x = direction; //Multiply x by direction.
        transform.localScale = tempScale; //Change player's local scale.
    }
     private void OnTriggerEnter2D (Collider2D collision) //Check when player collide with other objects.
     {
        if (collision.gameObject.CompareTag("BOOM"))  //If it collides with gameobject that has tag name "BOOM".
        {
            countHP -= 10; //Decrease HP by 10.
        }
        if (collision.gameObject.CompareTag("FAST")) //If it collides with gameobject that has tag name "FAST".
        {
            speed += 300; //Increase speed by 300.
        }
        if (collision.gameObject.CompareTag("SLOW")) //If it collides with gameobject that has tag name "SLOW".
        {
            speed -= 300; //Decrease speed by 300.
        }
        if (collision.gameObject.CompareTag("HP")) //If it collides with gameobject that has tag name "HP".
        {
            countHP += 10; //Increase HP by 10.
        }
        if (collision.gameObject.CompareTag("LAVA")) //If it collides with gameobject that has tag name "LAVA".
        {
            countHP -= 100; //Decrease HP by 100.
        }
        if (collision.gameObject.CompareTag("SCORE")) //If it collides with gameobject that has tag name "SCORE".
        {
            countScore += 20; //Increase score by 20.
        }
        if (collision.gameObject.CompareTag("SCENE")) //If it collides with gameobject that has tag name "SCENE".
        {
            countHP -= 20; //Decrease HP by 20.
        }
     }
}