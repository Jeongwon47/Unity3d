using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereReturn : MonoBehaviour {

	private Vector3 startingPoint;

	void Start () {
		startingPoint = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -4) {
			transform.position = startingPoint;	
		}
	}
}
