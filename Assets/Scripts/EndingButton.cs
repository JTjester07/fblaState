using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    // Called when the button using this script is pressed    
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
