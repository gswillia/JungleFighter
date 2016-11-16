using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class flloors : MonoBehaviour {


    public Button barButton;
    public Button closeButton;
    public Button concreteButton;
    public GameObject menu;
    public static bool conP=false;
    bool menuB = false;
    void Awake()
    {
        barButton = GetComponent<Button>(); // <-- you get access to the button component here
        menu.SetActive(false);
        barButton.onClick.AddListener(() => { showMenu(); });  // <-- you assign a method to the button OnClick event here
        closeButton.onClick.AddListener(() => { showMenu(); });
        concreteButton.onClick.AddListener(() => { placeConcrete(); });
    }

    void showMenu()
    {
        if (menuB == true)
        {
            menu.SetActive(false);
            menuB = false;
        }
        else
        {
            menu.SetActive(true);
            menuB = true;
        }
    }

    void placeConcrete()
    {
        menu.SetActive(false);
        menuB = false;
        conP = true;

    }
}
