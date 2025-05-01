using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinLoose : MonoBehaviour
{
    public void WinLevel()
    {
        StartCoroutine(GoToMainMenu());
        Debug.Log("You've gotten to work on time! Great Job! :)");
    }
    public void LooseLevel()
    {
        Debug.Log("You're late for work! You're kinda fired :(");
    }

    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(0);
    }
}
