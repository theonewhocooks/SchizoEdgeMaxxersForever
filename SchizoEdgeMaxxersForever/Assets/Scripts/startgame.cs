using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    [SerializeField] private string maingame = "Main Game";
    public GameObject settings;
    public GameObject menu;
    public GameObject closebutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void SettingsButton()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        closebutton.SetActive(true);
    }


    public void CloseButton()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        closebutton.SetActive(false);
    }
    
}