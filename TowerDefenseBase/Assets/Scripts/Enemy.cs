using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 5; 
	private Transform targetPathway; 
	private int waypointIndex; 

	// Use this for initialization
	void Start () {
		targetPathway = Pathway.points[0];
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = (targetPathway.position - this.transform.position);
		this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if ( Vector3.Distance(targetPathway.position, transform.position) <=0.2f) {
			getNextPath();
		}		
	}

	void getNextPath() {
		waypointIndex++;

		if( waypointIndex >= Pathway.points.Length){
			Destroy(gameObject);
			return;
		}
		targetPathway = Pathway.points[waypointIndex];
	}
}
