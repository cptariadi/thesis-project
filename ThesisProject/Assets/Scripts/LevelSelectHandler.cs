using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectHandler : MonoBehaviour {

	public int levelCode;
	public bool isLevelLocked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLevelLocked == false) {
		
			gameObject.GetComponent<Image> ().color = Color.green;

		} else {
		
			gameObject.GetComponent<Image> ().color = Color.red;
		}
		
	}


	public void GoToLevel(){
	
		if (isLevelLocked == false) {
			SceneManager.LoadScene ("Level" + levelCode);
		} else {
		

		}
	}

}
