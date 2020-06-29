using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private bool isRunning;
	private bool onLadder;
	private bool isJump;
	public bool onEvent;
	public float speed;
	public float jumpStrength;
	public float ladderingSpeed;
	public Vector3 playerTempPos;
	private float gravityNormal;
	private Vector3 laddering;
	private Rigidbody2D rb;
	private BoxCollider2D boxcollider;
	private float landMovement;

	private float tempspeed;

	public bool pauseMode;
	public GameObject menuPause;

	private bool jumpPressed;
	private bool tempJumpTrigger;

	private Animator playerAnimator;
	[SerializeField] private LayerMask lmLand;

	private Vector3 targetScale;

	private Vector3 cameraScale;
	[SerializeField] private GameObject mainCamera;

	void Start(){
		
		tempJumpTrigger = false;
		jumpPressed = false;
		isJump = false;
		playerAnimator = gameObject.GetComponent<Animator> ();

		onLadder = false;
		onEvent = false;
		rb = gameObject.GetComponent<Rigidbody2D> ();

		boxcollider = transform.GetComponent<BoxCollider2D> ();


		targetScale = transform.localScale;

		cameraScale = mainCamera.transform.localScale;

		isRunning = false;

		tempspeed = speed;

	}

	void OnTriggerEnter2D(Collider2D coll){

		LadderTrigger (coll, true);
		EventTrigger (coll, true);

	}

	void OnTriggerExit2D(Collider2D coll){

		LadderTrigger (coll, false);

	}


	void Update(){
	
		if (gameObject.GetComponent<PlayerStatus> ().isLose == false) {

			if (Input.GetKeyDown (KeyCode.Escape) && pauseMode == false) {

				pauseMode = true;
				menuPause.SetActive (true);

			} else if (Input.GetKeyDown (KeyCode.Escape) && pauseMode == true) {

				pauseMode = false;
				menuPause.SetActive (false);

			}



			if (pauseMode == false) {

				if (Input.GetKeyDown (KeyCode.W) && isGrounded ()) {
		
					tempJumpTrigger = true;
				}

				landMovement = Input.GetAxis ("Horizontal");

			}

		}

	}




	void FixedUpdate(){



		if (onEvent == false) {

			laddering = new Vector2 (0, ladderingSpeed);

			LadderingAction ();



			Vector3 movement = new Vector3 (landMovement, 0);

			if (landMovement != 0) {
			
				transform.localScale = new Vector3 (landMovement / Mathf.Abs (landMovement) * targetScale.x, targetScale.y, targetScale.z);

				mainCamera.transform.localScale = new Vector3 (landMovement / Mathf.Abs (landMovement) * cameraScale.x, cameraScale.y, cameraScale.z);
			}

			playerAnimator.SetFloat ("Speed", Mathf.Abs (landMovement));

			if(tempJumpTrigger == true/*Input.GetKeyDown (KeyCode.W) */&& jumpPressed == false && isJump == false){

				tempJumpTrigger = false;
				playerTempPos = transform.position;
				jumpPressed = true;

			}

			if (jumpPressed == true && onLadder == false && isJump == false) {


				rb.velocity = Vector2.up * jumpStrength;

				if (transform.position.y >= playerTempPos.y + 0.2f && isJump == false){


					isJump = true;
					jumpPressed = false;
					playerAnimator.SetBool ("isJumping", true);
				}
		
			}

			Run ();
			rb.AddForce (movement * speed);

		}

		if (isJump == true && isGrounded ()) {
			playerTempPos = new Vector3 (0, 0, 0);
			isJump = false;
			jumpPressed = false;
			playerAnimator.SetBool ("isJumping", false);
		}

		if (onEvent == true) {
		
			playerAnimator.SetBool ("isJumping", false);
			playerAnimator.SetFloat ("Speed", 0f);
		}




	}


	private bool isGrounded(){

		RaycastHit2D rchit = Physics2D.BoxCast (boxcollider.bounds.center, boxcollider.bounds.size, 0f, Vector2.down, 0.1f, lmLand);

		Debug.Log (rchit.collider);
		return rchit.collider != null;

		/*Debug.Log (gameObject.GetComponent<BoxCollider2D> ().IsTouching (GameObject.FindGameObjectWithTag ("land").GetComponent<BoxCollider2D>()));
		return gameObject.GetComponent<BoxCollider2D> ().IsTouching (GameObject.FindGameObjectWithTag ("land").GetComponent<BoxCollider2D>());
		*/
	}

	private void LadderTrigger(Collider2D coll, bool enterladder){
	
		if (coll.tag == "ladder" && enterladder == true) {
		

			onLadder = true;
			gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

		}

		if (coll.tag == "ladder" && enterladder == false) {


			onLadder = false;
			gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

		}




	}


	private void LadderingAction(){
	
		if (Input.GetKey (KeyCode.W) && onLadder) {
		
			Debug.Log ("koko");
			gameObject.transform.position += laddering;


		}
	
	
	}

	private void EventTrigger(Collider2D coll, bool enterEvent){

		if (coll.tag == "event" && enterEvent == true) {

			onEvent = true;
			rb.velocity = new Vector3 (0f, 0f, 0f);

		}



	}



	public void PauseMenu(){
	
		if (pauseMode == true) {
		
			pauseMode = false;
			menuPause.SetActive (false);
		} else if (pauseMode == false) {

			pauseMode = true;
			menuPause.SetActive (true);
		}


	}



	private void Run(){
	



		if (Input.GetKey (KeyCode.LeftShift)) {
		
			isRunning = true;
		} else {
		
			isRunning = false;
		}

		if (isRunning == true && speed <= (tempspeed * 2f)) {
		
			speed = tempspeed * 2;
		} else if (isRunning == false && speed != tempspeed) {
		
			speed = tempspeed;
		}

	}



}
