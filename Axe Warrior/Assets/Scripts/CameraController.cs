using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;

  private Vector3 offset;

  private Vector3 deathOffset;

  private Life life;


  

  // Start is called before the first frame update
  void Start()
  {
    offset = transform.position - player.transform.position;
    life = player.GetComponent<Life>();
  }

  // Update is called once per frame
  void Update()
  {

    if (life.dscream == true)
    {
        deathOffset = transform.position;
        transform.position = deathOffset;
    }
    else
    {
      transform.position = player.transform.position + offset;
    }
  }
}

