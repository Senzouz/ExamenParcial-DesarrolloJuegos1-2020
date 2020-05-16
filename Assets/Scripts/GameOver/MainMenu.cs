using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button btnMenu;

    private void Start()
    {
        btnMenu.onClick.AddListener(() => GoMenu());
    }
    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
