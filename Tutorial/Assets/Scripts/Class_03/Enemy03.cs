using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : MonoBehaviour {

	// Use this for initialization
	public Transform player;
	private Vector3 startingPosition;

	private Vector3 smoothVelocity = Vector3.zero;
	public float smoothTime = 10;
	void Start () {
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ( transform.position.y  < -20) {
			transform.position = startingPosition;
		}

		transform.LookAt(player);

		float distance = Vector3.Distance(transform.position, player.position);

		if (distance < 10) {
			transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
		}

		
	}
}
