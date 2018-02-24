using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour {

MeshRenderer meshR;

public GameObject bulletPrefab;
public GameObject bulletSpawn;

void Start()
  {
    meshR = GetComponent<MeshRenderer>();
    if (isLocalPlayer)
      {
        meshR.material.color = Color.blue;
      }else{
          meshR.material.color = Color.red;
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
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);

    bullet.GetComponent<Rigidbody>().velocity = Vector3.forward;

    NetworkServer.Spawn(bullet);
      Destroy(gameObject,2.0f);
    }
}
