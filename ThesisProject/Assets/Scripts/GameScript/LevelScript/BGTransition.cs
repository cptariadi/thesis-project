using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTransition : MonoBehaviour {

	private SpriteRenderer bgCover;
	[Tooltip("Smaller the value = More faster")] public float fadeSpeed;
	private Color bgCoverColor;
	private Collider2D playerObjColl;




	// Use this for initialization
	void Start () {
	
		bgCover = gameObject.GetComponent<SpriteRenderer> ();
		playerObjColl = GameObject.Find ("PlayerMain").GetComponent<BoxCollider2D> ();



	}
	
	// Update is called once per frame
	void Update () {




	}


	void OnTriggerEnter2D(Collider2D coll){

		if (coll == playerObjColl) {
		
			StartCoroutine ("ObjVanish");

		}

	}

	void OnTriggerExit2D(Collider2D coll){

		if (coll == playerObjColl) {

			StartCoroutine ("ObjVanishDisable");

		}

	}


	IEnumerator ObjVanish(){

			for (float i = 1f; i >= -0.05f; i -= 0.05f) {
			
				bgCoverColor = bgCover.color;
				bgCoverColor.a = i;
				bgCover.material.color = bgCoverColor;
			yield return new WaitForSeconds (fadeSpeed);


			}


	}

	IEnumerator ObjVanishDisable(){

		for (float i = -0.05f; i <= 1; i += 0.05f) {

			bgCoverColor = bgCover.color;
			bgCoverColor.a = i;
			bgCover.material.color = bgCoverColor;
			yield return new WaitForSeconds (fadeSpeed);


		}


	}






}
