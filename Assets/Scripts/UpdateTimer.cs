using UnityEngine;
using TMPro;

public class UpdateTimer : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    void Update()
    {
        pointsText.text = "Time: " + MainMenu.timer.ToString();
    }
}
