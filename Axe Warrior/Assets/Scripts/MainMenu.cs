using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isMute;
    public void PlayB()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitB(){
        Debug.Log("Game quit.");
        Application.Quit();
    }

    public void MuteB (){
        isMute = ! isMute;
        AudioListener.volume =  isMute ? 0 : 1;      
    }
}
