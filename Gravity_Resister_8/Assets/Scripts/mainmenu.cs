using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Make play game function to attach with button.
    }
    public void QuitGame()
    {
        Application.Quit(); //Make quit game function to attach the button.
    }
}
