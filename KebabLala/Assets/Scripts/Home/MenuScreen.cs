using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject btnGroup;
    [SerializeField] private GameObject creditGroup;

    public void GotoLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credit() {
        btnGroup.SetActive(false);
        creditGroup.SetActive(true);
    }

    public void Menu()
    {
        btnGroup.SetActive(true);
        creditGroup.SetActive(false);
    }
}
