using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAutoMove : MonoBehaviour {

	private Vector2 objCurrPos;
	private Vector2 objOriPos;

	[Tooltip("if verticalMove is on, this become up")]public float borderRangeRight;
	[Tooltip("if verticalMove is on, this become down")]public float borderRangeLeft;

	public float speed;
	public bool verticalMove;
	public bool useTrigger;
	public bool triggerOn;
	public bool isWall;

	private GameObject playerObj;
	private bool playerOnPlatform;


	// Use this for initialization
	void Start () {

		objOriPos = new Vector2 (gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y);


		playerObj = GameObject.Find ("PlayerMain");


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (playerObj.GetComponent<PlayerControl> ().pauseMode == false) {

			if (triggerOn == true) {
			
				gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (0, 158, 21, 255);
			} else if (triggerOn == false) {
			
				gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (0, 255, 33, 255);
			}

			objCurrPos = new Vector2 (gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y);

			if (useTrigger == false) {
		
				triggerOn = true;
			}

			if (triggerOn == true) {

				if (verticalMove == false) {

					if (objCurrPos.x >= (objOriPos.x + borderRangeRight)) {
		
						speed = speed * -1;

					} else if (objCurrPos.x <= (objOriPos.x - borderRangeLeft)) {
		
						speed = speed * -1;
					}
	

					transform.Translate (new Vector3 (2, 0, 0) * speed * Time.deltaTime);

					if (playerOnPlatform == true) {
						playerObj.transform.Translate (new Vector3 (2, 0, 0) * speed * Time.deltaTime);
					}


				} else if (verticalMove == true) {

					if (objCurrPos.y >= (objOriPos.y + borderRangeRight)) {

						speed = speed * -1;

					} else if (objCurrPos.y <= (objOriPos.y - borderRangeLeft)) {

						speed = speed * -1;
					}


					transform.Translate (new Vector3 (0, 2, 0) * speed * Time.deltaTime);
					if (playerOnPlatform == true) {
						playerObj.transform.Translate (new Vector3 (0, 2, 0) * speed * Time.deltaTime);
					}

				}
			}

		}


	}

	void OnCollisionStay2D(Collision2D coll){
	
		if (coll.gameObject.name == playerObj.name && playerObj.transform.position.y > (gameObject.transform.position.y) && isWall == false)
		{
		
			Debug.Log ("kokodayo");
			playerOnPlatform = true;

		}



	}


	void OnCollisionExit2D(Collision2D coll){

		if (coll.gameObject.name == playerObj.name) {

			playerOnPlatform = false;

		}

	}



	public void TurnTrigger(){
	
		if (useTrigger == true) {
		

			if (triggerOn == false) {

				triggerOn = true;

			} else if (triggerOn == true) {
			
				triggerOn = false;
			}


		}

	}



}
