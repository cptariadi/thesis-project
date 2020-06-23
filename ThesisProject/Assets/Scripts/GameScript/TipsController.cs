using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsController : MonoBehaviour {

	public GameObject tips;
	private GameObject playerObj;

	// Use this for initialization
	void Start () {
	
		playerObj = GameObject.Find ("PlayerMain");


	}
	
	// Update is called once per frame
	void Update () {




	}

	void OnTriggerEnter2D(Collider2D coll){
	
		if (coll.gameObject.name == playerObj.name) {
		
			tips.SetActive (true);
		
		}


	}
		
	void OnTriggerExit2D(Collider2D coll){
	
		if (coll.gameObject.name == playerObj.name) {

			tips.SetActive (false);

		}

	}



}
