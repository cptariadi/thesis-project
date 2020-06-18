using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {


	public GameObject indicator;
	public GameObject target;
	private GameObject playerObj;
	private bool onColl;



	// Use this for initialization
	void Start () {

		playerObj = GameObject.Find ("PlayerMain");

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.F) && target.tag == "platformMoving" && onColl) {

			target.GetComponent<PlatformAutoMove> ().TurnTrigger ();

		}


		if (target.GetComponent<PlatformAutoMove> ().triggerOn == false) {

			indicator.GetComponent<SpriteRenderer> ().color = Color.red;
		} else if (target.GetComponent<PlatformAutoMove> ().triggerOn == true) {

			indicator.GetComponent<SpriteRenderer> ().color = Color.green;
		}



	}

	void OnTriggerEnter2D(Collider2D coll){
	
		Debug.Log ("test");
		onColl = true;
	
	}

	void OnTriggerExit2D(Collider2D coll){


		onColl = false;

	}




}
