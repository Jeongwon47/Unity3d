using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Transform enemy;
	public Transform spawnObject; 
	public float timeBetweenWaves = 5f; 
	private float countdown = 2f; 
	private int waveIndex = 0;

	public Text WaveCountText;
	
	public Button WaveStartButton;

	void Start() {
		WaveStartButton.onClick.AddListener(forceWaveStart);
	}
	 void forceWaveStart()
    {
        Debug.Log("You have clicked the button!");
		countdown = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		if  (countdown <= 0f) {
			StartCoroutine(SpawnWave()); 
			countdown = timeBetweenWaves;
			
		}

		countdown -= Time.deltaTime; 

		WaveCountText.text = Mathf.Round(countdown).ToString(); 
	}


	void spawnEnemy(){
		Instantiate(enemy, spawnObject.position, spawnObject.rotation);
	}

	IEnumerator SpawnWave() {
		waveIndex++; 
		for(int i=0; i< waveIndex; i++) {
			spawnEnemy();
			yield return  new WaitForSeconds(0.5f);
		}
	}
}