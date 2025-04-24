using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;
using TMPro;

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

    public Material done;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    public GameObject canvas;

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
        life = 1000000000;
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
        button1.GetComponent<MeshRenderer>().material = done;
        Destroy(wire1a);
        Destroy(wire1b);
    }

    public void Wire2()
    {
        wire2 = true;
        button2.GetComponent<MeshRenderer>().material = done;
        Destroy(wire2a);
        Destroy(wire2b);
    }

    public void Wire3()
    {
        wire3 = true;
        button3.GetComponent<MeshRenderer>().material = done;
        Destroy(wire3a);
        Destroy(wire3b);
    }

    public void Wire4()
    {
        wire4 = true;
        button4.GetComponent<MeshRenderer>().material = done;
        Destroy(wire4a);
        Destroy(wire4b);
    }

    public void Wire5()
    {
        wire5 = true;
        button5.GetComponent<MeshRenderer>().material = done;
        Destroy(wire5a);
        Destroy(wire5b);
    }

    public void loseLife()
    {
        life--;
        canvas.GetComponent<TextMeshProUGUI>().text = "Life: " + life;
    }
}
