using Unity.VisualScripting;
using UnityEngine;

public class FuseBoxPuzzle : MonoBehaviour
{
    public GameObject win;

    public GameObject wire1a;
    public GameObject wire1b;
    public GameObject wire2a;
    public GameObject wire2b;
    public GameObject wire3a;
    public GameObject wire3b;
    public GameObject wire4a;
    public GameObject wire4b;
    public GameObject wire5a;
    public GameObject wire5b;

    private bool wire1;
    private bool wire2;
    private bool wire3;
    private bool wire4;
    private bool wire5;

    public int life;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wire1 = false;
        wire2 = false;
        wire3 = false;
        wire4 = false;
        wire5 = false;
        life = 10;
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wire1 && wire2 && wire3 && wire4 && wire5)
        {
            win.SetActive(true);
        }
        if(life < 0)
        {
            Application.Quit();
        }
    }

    public void Wire1()
    {
        wire1 = true;
        Destroy(wire1a);
        Destroy(wire1b);
    }

    public void Wire2()
    {
        wire2 = true;
        Destroy(wire2a);
        Destroy(wire2b);
    }

    public void Wire3()
    {
        wire3 = true;
        Destroy(wire3a);
        Destroy(wire3b);
    }

    public void Wire4()
    {
        wire4 = true;
        Destroy(wire4a);
        Destroy(wire4b);
    }

    public void Wire5()
    {
        wire5 = true;
        Destroy(wire5a);
        Destroy(wire5b);
    }
}
