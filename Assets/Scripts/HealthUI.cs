using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TMP_Text HealthTextBox;
    private Spaceship ship;
    void Start()
    {
        ship = FindFirstObjectByType<Spaceship>();
    }
    void Update()
    {
        if (ship != null)
        {
            HealthTextBox.text = "Health: " + ship.HealthCurrent.ToString();
        }
    }
}

