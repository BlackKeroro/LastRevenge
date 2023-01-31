using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class GameOver : MonoBehaviour
{
    PlayableDirector PB;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Game");
        PlayerController.isLoad = true;
    }
    public void OnExit()
    {
        Application.Quit();
        
    }
}
