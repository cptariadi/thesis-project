using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour {

	public GameObject playerObj;


	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.name == playerObj.name) {

			gameObject.SetActive (false);
		}


	}


}
