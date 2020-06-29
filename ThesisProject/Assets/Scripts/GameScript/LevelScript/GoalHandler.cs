using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour {

	public bool eventExist;
	private bool onGoal;
	public GameObject playerObj;
	public GameObject popup_LevelComplete;
	public int thisLevel;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (onGoal == true /*&& playerObj.GetComponent<PlayerControl> ().onEvent == false*/) {
		
			Debug.Log ("testter");

			if (playerObj.GetComponent<PlayerProgressionHandler> ().currentLevel == thisLevel) {

				playerObj.GetComponent<PlayerProgressionHandler> ().currentLevel = thisLevel + 1;
				gameObject.GetComponent<GameSaverLoader> ().SaveData ();

			}


			popup_LevelComplete.SetActive (true);

		}


		
	}

	void OnTriggerEnter2D(Collider2D coll){
	
		onGoal = true;


	}



	public void NextLevel(){
		
		SceneManager.LoadScene ("Level" + (thisLevel+1));

	}

	public void BacktoMenu(){
	
		SceneManager.LoadScene ("MainMenu");
	}





}
