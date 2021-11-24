using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemContr : MonoBehaviour
{
    public float speed;
    private Transform target;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 3){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
