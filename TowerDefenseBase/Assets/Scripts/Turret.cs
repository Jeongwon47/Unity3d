using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target; 

	[Header("Attributes")]
	public float range = 10f; 
	public float fireRate = 1f; 
	private float fireCountDown = 0f;
	public string enemyTag = "Enemy";
	public GameObject Bullet; 
	public Transform BulletPosition;

	[Header("Unity Setup Fields")]
	public Transform partToRotate; 
	public float turnSpeed = 10f; 
	
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    
    void UpdateTarget() {
       // Searching the nearest target    

		Debug.Log("UpdateTarget");

		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity; 
		GameObject nearestEnemy = null;

		foreach(GameObject enemy in enemies) {
			float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToenemy <= shortestDistance) {
				shortestDistance = distanceToenemy;
				nearestEnemy = enemy;
			}

			if (nearestEnemy != null && shortestDistance <=range) {
				target = nearestEnemy.transform;
			}
		}
}

	
	void Update () {
		
		if(target == null) {
			return;
		}

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation ,
							Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


		if (fireCountDown <= 0f) {
			Shoot();
			fireCountDown = 1f/ fireRate;
		}

		fireCountDown -= Time.deltaTime;
	}

	private void Shoot() {
		

		GameObject bulletGo = (GameObject)Instantiate(Bullet, BulletPosition.position,
		 BulletPosition.rotation);
		Bullet bullet = bulletGo.GetComponent<Bullet>();
		if( bullet != null) {
			bullet.Seek(target);
		}

	
	}

	void OnDrawGizmosSelected() {
		
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
