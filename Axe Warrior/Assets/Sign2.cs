using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign2 : MonoBehaviour
{ 
    public GameObject textbox2;
    [SerializeField] private string newlevel;

    void start()
    {
        textbox2.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Player")){
            textbox2.gameObject.SetActive(true);
            Debug.Log("Works");
            
    }
    }
    void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.CompareTag("Player")){
            textbox2.gameObject.SetActive(false);
            Debug.Log("Works2");
        }
    }
}

