using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Win : MonoBehaviour
{
    public WinLoose WinLooseScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinLooseScript.WinLevel();
        }
    }
}
