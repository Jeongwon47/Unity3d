using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
	public Material hoverMaterial;
	private Renderer rend;
	private Material startMaterial;

	public Vector3 turretOffset;

	private GameObject turret;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startMaterial = rend.material;
	}
	
	void OnMouseDown()
	{
		if (turret !=null) {
			Debug.Log("Can't build there");
			return;
		}		

		//build a turret
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
	}

	void OnMouseEnter() {
		Debug.Log("OnMouseEnter");
		rend.material = hoverMaterial;
	}

	void OnMouseExit() {
		Debug.Log("OnMouseExit");
		rend.material = startMaterial;
	}
}
