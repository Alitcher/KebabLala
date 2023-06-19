using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject btnGroup;
    [SerializeField] private GameObject creditGroup;
    // Start is called before the first frame update
    void Start()
    {
        Menu();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
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
