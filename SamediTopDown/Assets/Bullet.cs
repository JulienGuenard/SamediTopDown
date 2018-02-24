using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

  SpriteRenderer spriteR;

	void Start () {
      spriteR = GetComponent<SpriteRenderer>();

      if (isLocalPlayer)
      {
        spriteR.material.color = Color.blue;
      }else{
          spriteR.material.color = Color.red;
      }
	}

    void OnCollisionEnter (Collision collision)
 {
    Destroy(gameObject);
 }
 }
