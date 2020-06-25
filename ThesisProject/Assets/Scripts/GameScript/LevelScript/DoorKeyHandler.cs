using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyHandler : MonoBehaviour {

	public List<GameObject> Doors;
	public List<GameObject> Keys;
	private bool isUnlocked;
	private bool playerExist;
	public GameObject playerObj;
	public Sprite sprite_Locked;
	public Sprite sprite_Unlocked;
	int keyCount;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if (isUnlocked == false && HaveAllKeys () == true && playerExist == true && Input.GetKeyDown(KeyCode.F)) {
		
			isUnlocked = true;
		
		}/*else if (isUnlocked == true && playerExist == true && Input.GetKeyDown(KeyCode.F)) {
		
			isUnlocked = false;
		}*/

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
		
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_Unlocked;
			for (int j = 0; j < Doors.Count; j++) {
			
				Doors [j].SetActive (false);

			}

		} else if (isUnlocked == false) {
		
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_Locked;
			for (int j = 0; j < Doors.Count; j++) {

				Doors [j].SetActive (true);

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
