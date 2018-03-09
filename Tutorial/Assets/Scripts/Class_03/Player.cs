using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization

	public float speed = 10;

	Rigidbody rb;
	private Vector3 forceDirection;
	public float boost = 2;
	private bool isGrounded;
	void Start () {
		rb = GetComponent<Rigidbody>();
		forceDirection = new Vector3(0f, 2f, 0f);
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		transform.Translate(horizontal * speed * Time.deltaTime, 0f, 0f);

		if(Input.GetKeyDown("space") && isGrounded){
			Debug.Log("Key down Space!!!!");
			rb.AddForce(forceDirection * boost, ForceMode.Impulse);
			isGrounded = false;
		}

	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		Debug.Log("OnCollisionEnter!!!!");
		isGrounded = true;
	}
}
