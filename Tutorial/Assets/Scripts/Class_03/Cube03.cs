﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube03 : MonoBehaviour {

	public float speed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		transform.Translate(horizontal * speed * Time.deltaTime, 0f, vertical * speed * Time.deltaTime);
	}
}
