using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TurnOffLights : MonoBehaviour
{
    public GameObject lightObject;
    private bool isCoroutineRunning;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !isCoroutineRunning)
        {
            Destroy(lightObject);
            StartCoroutine(GoToMainMenu());
            isCoroutineRunning = true;
        }
    }

    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(0);
    }
}
