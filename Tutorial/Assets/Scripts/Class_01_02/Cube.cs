using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public float speed;
	
	void Update () {
		float Horizontal = Input.GetAxis("Horizontal");
		float Vertical = Input.GetAxis("Vertical");

		transform.Translate(speed * Horizontal * Time.deltaTime, 0f, speed * Vertical * Time.deltaTime); 

	}
}
