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
    public Light2D SUN;
    public Light2D FIRE;
    public TextMeshProUGUI healthtext;
    public GameObject deathText;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI matchestext;
    public GameObject Wintext;
    public int HP = 1;
    public float time = 60;
    private float timer, timerW = 0;
    public int Matches = 1;
    bool MainMenu;
    float random;
    private float nextActionTime = 1f;
    public float period = 0.1f;
    Platformer.Mechanics.PlayerController PC;
    public SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public bool dscream = false;
    Animator anim;
    CapsuleCollider2D playercoll;
    void Start()
    {
        anim = GetComponent<Animator>();
        MainMenu = true;
        deathText.SetActive(false);
        Wintext.SetActive(false);
        Sethealthtext();
        Setmatchestext();  
        PC = GetComponent<Platformer.Mechanics.PlayerController>();
        audioSource = GetComponent<AudioSource>();
        NewPlayer.SetActive(true);
        playercoll = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {   
        if(PC.velocity.x != 0){
            anim.SetBool("isWalking", true);
        }
        else{
            anim.SetBool("isWalking", false);
        }
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            FIRE.intensity = UnityEngine.Random.Range(0.4f,1f);
        }
        if (time > 0 && HP > 0){
            time -= Time.deltaTime;
            Settimetext();
            SUN.intensity = time*0.02f;
        }
        else{
            youlost();
        }

        if(Input.GetKeyDown("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if(Input.GetKeyDown("e")){
            Debug.Log("Works");
            MainMenu = false;
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
    void SetWintext(){ //Updates Matchestext
        Wintext.SetActive(true);
        timerW += Time.deltaTime;
        PC.maxSpeed = 0;
        PC.jumpTakeOffSpeed = 0;
        time = 10000000000000;
        if (timerW > 5)
        {
            MainMenu = true;
            Debug.Log("Menu");
        }
    }
     void youlost(){ // Update is called once per frame
        deathText.SetActive(true);
        PC.maxSpeed = 0;
        PC.jumpTakeOffSpeed = 0;
        anim.SetBool("isDead", true);
        playercoll.size = new Vector2(playercoll.size.x, 0.01f);
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
            time += 5;
        }
        if (other.gameObject.CompareTag("BambuSpikes")){
            HP -= 1;
            Sethealthtext();
        }
        if (other.gameObject.CompareTag("Win")){
            SetWintext();
        }
        
    }
    public void OnTriggerStay2D(Collider2D other){   //Checks if trigger collision stays
            
        if (other.gameObject.CompareTag("Fire"))
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                HP -= 1;
                Sethealthtext();
            }
        }
    }
    
    public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Fire")){
            timer = 0;
        }
    }
}
