using UnityEngine;
using TMPro;

public class AlienCounter : MonoBehaviour
{
    public static AlienCounter Instance;

    [SerializeField] private TextMeshProUGUI aliensLeftText;
    private int aliensAlive = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterAlien()
    {
        aliensAlive++;
        UpdateUI();
    }

    public void AlienDied()
    {
        aliensAlive--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        aliensLeftText.text = "Aliens Left: " + aliensAlive;
    }
}
