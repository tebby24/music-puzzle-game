using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] int sceneNumber;

    //function that loads a scene
    public void load(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    //loads the next scene on button press
    public void onButtonPress()
    {
        load(sceneNumber + 1);
    }

    //quits game
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }


    void Update()
    {
        //restarts scene
        if (Input.GetKeyUp(KeyCode.R))
        {
            load(sceneNumber);
        }
    }
}




