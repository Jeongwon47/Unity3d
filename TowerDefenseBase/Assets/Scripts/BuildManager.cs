﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance; 

	public GameObject standardTurretPrefab;
	private GameObject turretToBuild;
	
	void Awake() {

		if (instance !=null){
			return;
		}

		instance = this;	
	}

	void Start()
	{
		turretToBuild = standardTurretPrefab;
	}

	public GameObject GetTurretToBuild() {
		return turretToBuild;
	}
}
