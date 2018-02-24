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

	void Update()
  {
    if (isLocalPlayer)
      {
        transform.position += new Vector3(Input.GetAxis("Horizontal") / 3, 0, Input.GetAxis("Vertical") / 3);

        ChangeRotation();

          if (Input.GetKeyDown(KeyCode.Space)) 
          {
            CmdShoot();
          }
       }
	}

    [Command]
    void CmdShoot () 
    {
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);

    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward*4;

    NetworkServer.Spawn(bullet);
      Destroy(bullet.gameObject,2.0f);
    }

    void ChangeRotation ()
    {
      if (Input.GetAxis("Horizontal") > 0)
          {
          transform.localRotation = Quaternion.Euler(0, 90, 0);
            if (Input.GetAxis("Vertical") > 0)
              {
              transform.localRotation = Quaternion.Euler(0, 45, 0);
              }
            if (Input.GetAxis("Vertical") < 0)
              {
              transform.localRotation = Quaternion.Euler(0, 135, 0);
              }
          }

          if (Input.GetAxis("Horizontal") < 0)
          {
          transform.localRotation = Quaternion.Euler(0, 270, 0);
            if (Input.GetAxis("Vertical") > 0)
              {
              transform.localRotation = Quaternion.Euler(0, 315, 0);
              }
            if (Input.GetAxis("Vertical") < 0)
              {
              transform.localRotation = Quaternion.Euler(0, 235,0 );
              }
          }

          if (Input.GetAxis("Horizontal") == 0) 
          {
              if (Input.GetAxis("Vertical") < 0)
              {
              transform.localRotation = Quaternion.Euler(0, 180, 0);
              }
              if (Input.GetAxis("Vertical") > 0)
              {
                  transform.localRotation = Quaternion.Euler(0, 0, 0);
              }
          }
    }

}
