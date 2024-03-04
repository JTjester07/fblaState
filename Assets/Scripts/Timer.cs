using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public string nextScene; // Name of the scene to load when countdown reaches 0

    private void Start()
    {
        // Start the countdown coroutine
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        // Repeat until count reaches 0
        while (MainMenu.timer > 0)
        {
            // Decrement count by 1
            MainMenu.timer--;

            // Wait for 1 second before decrementing again
            yield return new WaitForSeconds(1f);
        }

        // Countdown has finished
        Debug.Log("Countdown finished!");

        // Load the specified scene
        SceneManager.LoadScene(nextScene);
    }
}
