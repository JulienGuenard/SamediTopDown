using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

Rigidbody rigidbody;

void Start () {
    rigidbody = GetComponent<Rigidbody>();
}

	void Update () {
      rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal")*100, Input.GetAxis("Vertical")*100,0); 
	}
}
