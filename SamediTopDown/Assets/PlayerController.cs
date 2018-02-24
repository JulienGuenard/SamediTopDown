using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour {

SpriteRenderer spriteR;

public GameObject bulletPrefab;
public Vector3 bulletSpawn;

void Start()
  {
    spriteR = GetComponent<SpriteRenderer>();
    if (isLocalPlayer)
      {
        spriteR.material.color = Color.blue;
      }else{
          spriteR.material.color = Color.red;
      }
}

	void Update () 
    {
    if (isLocalPlayer) {
          transform.position += new Vector3(Input.GetAxis("Horizontal")/2, 0, Input.GetAxis("Vertical")/2);

          if (Input.GetKeyDown(KeyCode.Space)) 
          {
            CmdShoot();
          }
       }
	}

    [Server]
    void CmdShoot () 
    {
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, transform.rotation);

    bullet.GetComponent<Rigidbody>().velocity = Vector3.forward;

    NetworkServer.Spawn(bullet);
      Destroy(gameObject,2.0f);
    }
}
