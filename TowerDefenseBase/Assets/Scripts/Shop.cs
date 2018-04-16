using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;
	void Start()
	{
		buildManager = BuildManager.instance;		
	}

	public void PurchaseStandardTurret(){
		Debug.Log("PurchaseStandardTurret");
		buildManager.setTurretTobuild(buildManager.standardTurretPrefab);
	}

	public void PurchaseAnotherTurret(){
		Debug.Log("PurchaseAnotherTurret");
		buildManager.setTurretTobuild(buildManager.anotherTurretPrefab);
	}

}
