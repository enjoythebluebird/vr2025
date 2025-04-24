using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level2 : MonoBehaviour
{
    public int items;
    public GameObject win;

    public GameObject placement1;
    public GameObject placement2;
    public GameObject placement3;
    public TextMeshPro text;

    void Start()
    {
        items = 0;
        win.SetActive(false);

        // Ensure the PlacementTrigger script has a reference to this Level2 script
        PlacementTrigger placementTrigger = placement1.GetComponent<PlacementTrigger>();
        if (placementTrigger != null)
        {
            placementTrigger.level2 = this;
        }
    }

    void Update()
    {
        if (items == 3)
        {

            win.SetActive(true);
        }
    }

    public void IncreaseItems()
    {
        items++;
    }

    public void DecreaseItems()
    {
        items--;
    }

    public void setString(string[] tags)
    {
        string str = "";
        if (tags.Length == 0)
        {
            str = "Press the red button on the camera to start filming!!!";
            text.text = str;
            return;
        }
        str = "Don't forget to place: ";
        for (int i = 0; i < tags.Length; i++)
        {
            str = str + tags[i] + " ";
        }
        text.text = str;
    }
}
