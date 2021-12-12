using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{   
    bool sound = false;
    AudioSource audioSource2;

    void start()
    {   

        audioSource2 = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Player")){
                if (!sound){
                        audioSource2.Play();
                        Debug.Log("Appplause");
                        sound = true;
    }
}
}
}
    