using UnityEngine;
using System.Collections.Generic;

public class PlacementTrigger : MonoBehaviour
{
    public Level2 level2;
    private HashSet<Collider> objectsInTrigger = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (!objectsInTrigger.Contains(other))
        {
            Debug.Log("Object entered the trigger for placement1.");
            objectsInTrigger.Add(other);
            level2.IncreaseItems();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInTrigger.Contains(other))
        {
            Debug.Log("Object exited the trigger for placement1.");
            objectsInTrigger.Remove(other);
            level2.DecreaseItems();
        }
    }
}

