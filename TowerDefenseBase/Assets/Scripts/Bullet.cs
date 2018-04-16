using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public GameObject BulletImpactEffect;
	private Transform target;
	public float speed = 20f;
	

	public void Seek(Transform _target) {
		target = _target;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;

		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		
	}

	private void HitTarget() {

		GameObject bulletImpactEffect = (GameObject)Instantiate(BulletImpactEffect, target.transform.position, target.transform.rotation);
		Destroy(bulletImpactEffect, 0.5f);
		Destroy(target.gameObject);

		Destroy(gameObject);
	}
}
