using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressionHandler : MonoBehaviour {

	public int currentLevel;
	private int levelPointer;

	void Update(){

		levelPointer = 1;

		do {



			if(GameObject.Find ("Level" + levelPointer).GetComponent<LevelSelectHandler>().levelCode <= currentLevel){

				GameObject.Find ("Level" + levelPointer).GetComponent<LevelSelectHandler>().isLevelLocked = false;

			}else{

				GameObject.Find ("Level" + levelPointer).GetComponent<LevelSelectHandler>().isLevelLocked = true;
			}

			levelPointer++;


		} while (GameObject.Find ("Level" + levelPointer) != null);



	}




}
