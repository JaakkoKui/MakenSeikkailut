using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textbox : MonoBehaviour
{ 
    public GameObject textbox;
    [SerializeField] private string newlevel;

    void start()
    {
        textbox.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Player")){
            textbox.gameObject.SetActive(true);
            Debug.Log("Works");
            
    }
    }
    void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.CompareTag("Player")){
            textbox.gameObject.SetActive(false);
            Debug.Log("Works2");
        }
    }
}

