using UnityEngine;

public class Level2 : MonoBehaviour
{
    public int items;
    public GameObject win;

    public GameObject placement1;
    public GameObject placement2;

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
        if (items == 2)
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
}
