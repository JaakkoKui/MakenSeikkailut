using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Experimental.Rendering.Universal;

public class Life : MonoBehaviour
{
    public GameObject NewPlayer;
    public Light2D SUN1;
    public Light2D FIRE;
    public TextMeshProUGUI healthtext;
    public GameObject deathText;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI matchestext;
    public int HP = 1;
    public float time = 60;
    private float timer = 0;
    public int Matches = 1;
    bool MainMenu;
    float random;
    private float nextActionTime = 1f;
    public float period = 0.1f;
    Platformer.Mechanics.PlayerController PC;
    public SpriteRenderer spriteRenderer;
    public Sprite deadMake;
    AudioSource audioSource;
    private bool dscream = false;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu = true;
        deathText.SetActive(false);
        Sethealthtext();
        Setmatchestext();  
        PC = GetComponent<Platformer.Mechanics.PlayerController>();
        audioSource = GetComponent<AudioSource>();
        NewPlayer.SetActive(true);
    }
    void Update()
    {   
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
//            FIRE.intensity = UnityEngine.Random.Range(0.6f,1f);
        }
        if (time > 0 && HP > 0){  //Timer updater
            time -= Time.deltaTime;
            Settimetext();
            SUN1.intensity = time*0.02f;
        }
        else{ //Displays youlosttext if HP or time runs out
            youlost();
        }

        if(Input.GetKeyDown("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if(Input.GetKeyDown("e")){
            Debug.Log("Works");
            MainMenu = true;
        }
    }

    void Sethealthtext(){   //Updates Healthtext
        healthtext.text = "Health: " + HP.ToString();
    }
    void Settimetext(){ //Updates Timetext
        timetext.text = "Time remaining: " + Convert.ToInt16(time);
    }
    void Setmatchestext(){ //Updates Matchestext
        matchestext.text = "Matches: " + Matches.ToString();
    }
     void youlost(){ // Update is called once per frame
        deathText.SetActive(true);
        PC.maxSpeed = 0;
        PC.jumpTakeOffSpeed = 0;
        spriteRenderer.sprite = deadMake;
        if (!dscream){
        audioSource.Play();
        Debug.Log("Wilhelm");
        dscream = true;
        }
        timer += Time.deltaTime;
        if (timer > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) //Check collision with trigger tags happen
    {
        if (other.gameObject.CompareTag("Enemy")){
            HP -= 1;
            Sethealthtext();
        }
        if (other.gameObject.CompareTag("Matches")){
            Matches += 1;
            other.gameObject.SetActive(false);
            Setmatchestext();
        }
        if (other.gameObject.CompareTag("BambuSpikes")){
            HP -= 1;
            Sethealthtext();
        }
    }
    public void OnTriggerStay2D(Collider2D other){   //Checks if trigger collision stays
            if (other.gameObject.CompareTag("Fire")){
            timer += Time.deltaTime;
            if (timer > 3){
                HP -= 1;
                Sethealthtext();
            }
}
}
}
