using UnityEngine;
using System.Collections.Generic;

public class PlacementTrigger : MonoBehaviour
{
    public Level2 level2;
    private HashSet<Collider> objectsInTrigger = new HashSet<Collider>();
    private static List<string> tags = new List<string>();
    private static bool isInitialized = false; // Static flag to ensure initialization happens once

    private void Start()
    {
        if (!isInitialized)
        {
            // Initialize the shared tags list and set the initial string
            tags.Add("Flag");
            tags.Add("Astronaut");
            tags.Add("Earth");
            level2.setString(tags.ToArray());
            isInitialized = true; // Mark as initialized
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectsInTrigger.Contains(other))
        {
            Debug.Log("Object entered the trigger for placement1.");
            objectsInTrigger.Add(other);
            if (other.tag == "Flag" || other.tag == "Astronaut" || other.tag == "Earth")
            {
                tags.Remove(other.tag);
                level2.setString(tags.ToArray());
            }
            level2.IncreaseItems();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInTrigger.Contains(other))
        {
            Debug.Log("Object exited the trigger for placement1.");
            objectsInTrigger.Remove(other);

            // Re-add the tag to the list if it matches one of the predefined tags
            if (other.tag == "Flag" || other.tag == "Astronaut" || other.tag == "Earth")
            {
                if (!tags.Contains(other.tag)) // Avoid duplicates
                {
                    tags.Add(other.tag);
                    level2.setString(tags.ToArray());
                }
            }

            level2.DecreaseItems();
        }
    }
}
