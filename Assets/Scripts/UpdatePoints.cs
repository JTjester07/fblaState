using UnityEngine;
using TMPro;

public class UpdatePoints : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    void Update()
    {
        pointsText.text = "Power: " + MainMenu.points.ToString();
    }
}
