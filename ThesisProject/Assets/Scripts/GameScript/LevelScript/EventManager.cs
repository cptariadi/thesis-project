using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public List<GameObject> textDialogue;
	public Collider2D eventTrigger;
	private bool isRunning;
	private int currEvent;
	private Collider2D playerObjColl;
	private PlayerControl playerControlScript;


	// Use this for initialization
	void Start () {

		currEvent = 0;
		isRunning = false;
		playerObjColl = GameObject.Find ("PlayerMain").GetComponent<BoxCollider2D> ();
		playerControlScript = GameObject.Find ("PlayerMain").GetComponent<PlayerControl> ();

	}
	
	// Update is called once per frame
	void Update () {




		if (isRunning == true) {
		

			if (textDialogue [0] == null) {
			
				isRunning = false;
				playerControlScript.onEvent = false;
				gameObject.SetActive (false);

			}

			if (textDialogue [0] != null) {

				textDialogue [currEvent - 1].SetActive (true);


				if (Input.GetKeyDown (KeyCode.Return)) {
			
					textDialogue [currEvent - 1].SetActive (false);
					currEvent++;
				}

				if (currEvent > textDialogue.Count) {
			
					isRunning = false;
					playerControlScript.onEvent = false;
					gameObject.SetActive (false);
				}



			}
		}



	}

	void OnTriggerEnter2D(Collider2D coll){
	
		if (coll == playerObjColl) {
			
			isRunning = true;
			currEvent = 1;
		}



	}






}
