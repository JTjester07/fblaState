using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Called when the button using this script is pressed    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
