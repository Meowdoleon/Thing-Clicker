using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public GameObject menu;

    public void openMenu()
    {
        menu.SetActive(true);
    }

    public void closeMenu()
    {
        menu.SetActive(false);
    }

    public void changeScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
