using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {

	public Button cameraButton;
	public GameObject mainCamera;
	public GameObject personCamera;
	// Use this for initialization
	void Start () {
		Button btn1 = cameraButton.GetComponent<Button>();
		btn1.onClick.AddListener(handleCamera); 

	}
	
	void handleCamera() {
		mainCamera.SetActive(!mainCamera.activeSelf);
		personCamera.SetActive(!personCamera.activeSelf);

	}
}
