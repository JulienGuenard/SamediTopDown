using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class PlayerController : NetworkBehaviour {

MeshRenderer meshR;

public GameObject bulletPrefab;
public GameObject bulletSpawn;

Rigidbody rigidbody;

void Start()
  {
    rigidbody = GetComponent<Rigidbody>();
    meshR = GetComponent<MeshRenderer>();
    if (isLocalPlayer)
      {
        GetComponent<cakeslice.Outline>().color = 3;
        meshR.material.color = Color.blue;
      }else{
          GetComponent<cakeslice.Outline>().color = 0;
          meshR.material.color = Color.red;
      }
}

	void Update()
  {
    if (isLocalPlayer)
      {
        transform.position += new Vector3(Input.GetAxis("Horizontal") / 3, 0, Input.GetAxis("Vertical") / 3);

        rigidbody.velocity = Vector3.zero;

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

    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward*15;

    NetworkServer.Spawn(bullet);
      Destroy(bullet.gameObject,6.0f);
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
