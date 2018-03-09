using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform player;

	public Vector3 offset;
	public float smoothSpeed = 0.125f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 desirePosition = player.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
		transform.position= smoothedPosition;
		
		transform.LookAt(player);
	}
}
