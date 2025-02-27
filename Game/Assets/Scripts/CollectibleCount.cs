using UnityEngine;
using System;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    private TMP_Text text;
    private int count;

    // Declare an event or delegate
    public static event Action OnCollectibleCollected; 

    void Start() => UpdateCount();

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void OnEnable() => OnCollectibleCollected += UpdateCount; 
    void OnDisable() => OnCollectibleCollected -= UpdateCount; 

    public static void CollectiblePickedUp()
    {
        OnCollectibleCollected?.Invoke(); 
    }

    void UpdateCount()
    {
        count++;
        text.text = $"{count} / {Collectible.total}";
    }
}
