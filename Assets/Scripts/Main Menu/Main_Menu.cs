using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //load game level
    public void NewGame()
    {
        SceneManager.LoadScene("World");
    }

    //quit game to desktop
    public void QuitGame()
    {
        Application.Quit();
    }
}
