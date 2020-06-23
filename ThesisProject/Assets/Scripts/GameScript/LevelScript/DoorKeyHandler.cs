using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyHandler : MonoBehaviour {

	public List<GameObject> Doors;
	public List<GameObject> Keys;
	private bool isUnlocked;
	private bool playerExist;
	public GameObject playerObj;
	int keyCount;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if (isUnlocked == false && HaveAllKeys () == true && playerExist == true && Input.GetKeyDown(KeyCode.F)) {
		
			isUnlocked = true;
		
		}

		if (isUnlocked == true && playerExist == true && Input.GetKeyDown(KeyCode.F)) {
		
			isUnlocked = false;
		}

		DoorOpen ();


	}



	private bool HaveAllKeys(){
	
		for (int i = 0; i < Keys.Count; i++) {
		
			if (Keys [i].activeSelf == true) {
			
				return false;
			}

		}

		return true;

	}


	private void DoorOpen(){
	
	
		if (isUnlocked == true) {
		
			for (int j = 0; j < Doors.Count; j++) {
			
				Doors [j].SetActive (true);

			}

		} else if (isUnlocked == false) {
		
			for (int j = 0; j < Doors.Count; j++) {

				Doors [j].SetActive (false);

			}
		}


	}

	void OnTriggerEnter2D(Collider2D coll){
	
		if (coll.gameObject.name == playerObj.name) {

			playerExist = true;
		}


	}

	void OnTriggerExit2D(Collider2D coll){

		if (coll.gameObject.name == playerObj.name) {

			playerExist = false;
		}


	}





}
