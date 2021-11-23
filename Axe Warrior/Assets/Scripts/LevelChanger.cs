using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private string newlevel;
    void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("Level 2");
            Debug.Log("Works");
    }
}
}
