using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	public float speed;
	private Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float Horizontal = Input.GetAxis("Horizontal");
		float Vertical = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);
		rigid.AddForce(move * speed);
	}
}
