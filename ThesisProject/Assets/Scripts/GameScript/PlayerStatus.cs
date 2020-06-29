using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

	public int health;
	public GameObject[] healthObj;
	private bool immunity;
	public Animator[] healthObjAnimator;
	public GameObject GameOverScreen;
	public bool isLose;
	public GameObject[] Stars;



	// Use this for initialization
	void Start () {
		
		immunity = false;
		isLose = false;


	}
	
	// Update is called once per frame
	void Update () {

		HealthUpdate ();

		if (health <= 0 && isLose == false) {
		
			isLose = true;
			GameOverScreen.SetActive (true);
		}




	}


	private void HealthUpdate(){

		if (health == 3) {

			//healthObj [0].GetComponent<Image> ().color = Color.green;
			healthObjAnimator [0].SetBool ("Damaged", false);
			//healthObj [1].GetComponent<Image> ().color = Color.green;
			healthObjAnimator [1].SetBool ("Damaged", false);
			//healthObj [2].GetComponent<Image> ().color = Color.green;
			healthObjAnimator [2].SetBool ("Damaged", false);

			Stars [0].GetComponent<Image> ().color = Color.white;
			Stars [1].GetComponent<Image> ().color = Color.white;
			Stars [2].GetComponent<Image> ().color = Color.white;

		} else {


			for (int i = 0; i < health; i++) {
					
				//healthObj [i].GetComponent<Image> ().color = Color.green;
				healthObjAnimator [i].SetBool ("Damaged", false);

			}
			

			for (int j = 2; j > (health - 1); j--) {

				//healthObj [j].GetComponent<Image> ().color = Color.red;
				healthObjAnimator [j].SetBool ("Damaged", true);
			}


		}

		if (health == 2) {
		
			Stars [0].GetComponent<Image> ().color = Color.white;
			Stars [1].GetComponent<Image> ().color = Color.white;
			Stars [2].GetComponent<Image> ().color = Color.black;
		
		} else if (health == 1) {
		
			Stars [0].GetComponent<Image> ().color = Color.white;
			Stars [1].GetComponent<Image> ().color = Color.black;
			Stars [2].GetComponent<Image> ().color = Color.black;
		}





	}



	void OnCollisionStay2D(Collision2D coll){

		if (coll.gameObject.tag == "trap" && immunity == false) {
			Debug.Log ("hit");
			if (health != 0) {
				health--;
			}
			StartCoroutine ("ImmunityAfterHit");


		}
			

	}


	IEnumerator ImmunityAfterHit(){

		Debug.Log ("numerator");
		immunity = true;
		yield return new WaitForSeconds (3f);

		immunity = false;


	}



	public void RetryLevel(){
	
		if (isLose == true) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}



}
