using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public Button sceneButton01;
	public Button sceneButton02;
	public Button sceneButton03;
	
    void Start()
    {
        Button btn1 = sceneButton01.GetComponent<Button>();
		btn1.onClick.AddListener(() => {TaskOnClick(1);}); 

		Button btn2 = sceneButton02.GetComponent<Button>();        
		btn2.onClick.AddListener(() => {TaskOnClick(2);}); 

		Button btn3 = sceneButton03.GetComponent<Button>();        
		btn3.onClick.AddListener(() => {TaskOnClick(3);}); 
    }

    void TaskOnClick(int sceneNum)
    {
		LoadMyScene("Scene"+sceneNum);
    }

	void LoadMyScene(string sceneName)
 	{
 		SceneManager.LoadScene(sceneName);
 	}
}
