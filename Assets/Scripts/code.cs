// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// //Vector3(47.519001,-113.843002,33.6469994) 0.08800001
// public class player : MonoBehaviour
// {
//     public Animator playerAnim;
// 	public Transform target;
// 	public Rigidbody playerRigid;

// 	public float speed, wb_speed, olspeed, rn_speed, ro_speed;
// 	public bool walking;
// 	public bool Grounded = false;
// 	public Transform Bp; 
// 	public Transform playerTrans;
// 	public CharacterController controller;
// 	[SerializeField] private Camera cam;
// 	RaycastHit hit;
	
// 	public CapsuleCollider myCollider;

// 	private bool Ag = false;
// 	void Start(){
// 		myCollider = GetComponent<CapsuleCollider>();
// 		//controller = gameObject.AddComponent<CharacterController>();
// 	}
// 	void FixedUpdate(){
// 		float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");
// 		// if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,  0.13f )){
// 		// playerRigid.useGravity = false;
// 		// Grounded = true;
// 		// transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
// 		// //Vector3 playerPosition = hit.point  + new Vector3(0,0.08800001f,0); 
// 		// //transform.position = playerPosition;
// 		// Debug.Log(transform.up + new Vector3(0,0.08800001f,0));
		
		
// 		// //transform.SetPositionAndRotation(hit.point + transform.position,Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
// 		// }
// 		// else{
// 		// 	//playerRigid.useGravity = true;
// 		// 	Grounded = false;
// 		// 	transform.localEulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0);
// 		// }
//         // Debug.DrawRay(transform.position, new Vector3(0, -0.13f, 0)  , Color.yellow);
// 		// if(!Grounded){
			
// 		// }
// 		// if(Input.GetKey(KeyCode.W)){
// 		// 	speed = 120;
// 		// }
// 		//  else
//         // {
// 		// 	speed = 0;
//         // }
		
// 		// //&& playerRigid.velocity.y<=0
// 		// Debug.Log(playerRigid.useGravity);
// 		// if(Input.GetKey(KeyCode.Space) && Grounded  ){
// 		// 	playerRigid.AddForce(new Vector3(0,1,0) * 10000 * Time.deltaTime);
// 		// }
// 		// 
// 		//playerRigid.AddForce(transform.forward * speed * Time.deltaTime);
// 		//playerRigid.velocity = Vector3.zero;
// 		//playerRigid.velocity = new Vector3(0,-1,0) * 100 * Time.deltaTime;
// 		//transform.position = hit.point - CapsuleCollider.size * 0.5f;
// 		//BoxCollider playerCollider = player.GetComponent<BoxCollider>();
//         //Vector3 playerPosition = hit.point + (Vector3.up ); //hit.point - myCollider.height * 0.5f;
// 		//transform.position = playerPosition;
// 		//transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
// 		//Debug.Log(Vector3.up);
// 		// playerRigid.velocity = new Vector3(0,-1,0) * 100 * Time.deltaTime;
// 			// return;
// 		//playerRigid.velocity = transform.forward * speed * Time.deltaTime;
// 		//Vector3 ad = transform.forward * speed * Time.deltaTime;
// 		//playerRigid.velocity += ad;
// 	}
// 	void Update(){
// 		if(Input.GetKeyDown(KeyCode.W)){
// 			// Vector3 move = new Vector3(1, 0, 0);
// 			// controller.Move( move* Time.deltaTime * 10);
// 			if(controller.isGrounded){
// 				print("CharacterController is grounded");
// 			   // Debug.Log('img');
// 			if(Input.GetKeyDown(KeyCode.Space)){
// 				print("space pressed");
			
// 			}
// 		}
// 		// float horizontalInput = Input.GetAxis("Horizontal");
//         // float verticalInput = Input.GetAxis("Vertical");

//         // Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
//         // movement *= 120 * Time.deltaTime;

//         // // Apply movement to the Character Controller
//         // controller.Move(movement);
// 		// playerRigid.AddForce(Vector3.up * 5f, ForceMode.Impulse);
//         // if (controller.isGrounded && Input.GetButtonDown("Jump"))
//         // {
// 		// 	Debug.Log('y');
//         //     // Apply jump force to the Rigidbody
//         //     playerRigid.AddForce(Vector3.up * 5f, ForceMode.Impulse);
//         // }		
// 			//}
// 			//playerRigid.useGravity = false;
// 			// Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));
// 			// move = transform.TransformDirection(move);
// 			// move *= 3;
// 			// Debug.Log(move);
// 		    // controller.Move(move * Time.deltaTime);
// 			// transform.Rotate(0, Input.GetAxisRaw("Horizontal"), 0);
// 			//playerRigid.useGravity = true;
// 			//}
// 		    //float gravity = 9.8f;
// 			// Vector3 gravityForce = new Vector3(0f, -gravity * playerRigid.mass, 0f);
//             // playerRigid.AddForce(gravityForce);
// 			//playerRigid.AddForce(new Vector3(0, -100, 0), ForceMode.Acceleration);
// 			// // Debug.Log(transform.forward);
// 			// // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//             // // Vector3 movement =  move * 120 * Time.deltaTime;
//             // // controller.Move(movement);
// 			// playerAnim.SetTrigger("jog");
// 			// playerAnim.ResetTrigger("idle");
// 			// walking = true;
// 		//}
// 		// if(Input.GetKeyUp(KeyCode.W)){
// 		// 	playerAnim.ResetTrigger("jog");
// 		// 	playerAnim.SetTrigger("idle");
// 		// 	walking = false;
// 		// }
// 		// if(Input.GetKey(KeyCode.A)){
// 		// 	playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
// 		// }
// 		// if(Input.GetKey(KeyCode.D)){
// 		// 	playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
// 		// }
// 		}
// 	}
// }

// // playerRigid.useGravity = false;
// 		//playerRigid.velocity = Vector3.zero;
// 		// Vector3 groundFacingDirection = hit.normal;
 
//         // groundAngle = Vector3.Angle(verticalDirection, groundFacingDirection);
// 		//transform.up = hit.normal;
// 		//transform.position = hit.point;
// 		//transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
// 	    //transform.position = hit.point;
// 		//  Debug.Log("hit");
// 		// Debug.Log("me worked");
// 		// playerRigid.velocity = Vector3.zero;
// 		//transform.Translate(Vector3.forward * Time.deltaTime);

// // void FixedUpdate(){
// // 		//playerRigid.velocity = Vector3.zero;
// // 		// Vector3 groundFacingDirection = hit.normal;
// // 		//transform.Translate(Vector3.down * Time.deltaTime *10);
// //         // Vector3 verticalDirection = Vector3.up; // same as Vector3(0,1,0)
 
// //         // groundAngle = Vector3.Angle(verticalDirection, groundFacingDirection);

		
// //         Debug.DrawRay(transform.position, new Vector3(0, -0.43f, 0)  , Color.yellow);
// // 		if(Input.GetKey(KeyCode.W)){
// // 			playerRigid.velocity = transform.forward * speed * Time.deltaTime;
// // 			//transform.Translate(Vector3.forward * Time.deltaTime *10);
// // 			//cam.transform.Translate(Vector3.forward * Time.deltaTime *10);
// // 		}
// // 		else
// //         {
// // 			Debug.Log("me worked");
// //             playerRigid.velocity = Vector3.zero;
// //         }
// // 		if(Input.GetKey(KeyCode.S)){
// // 			//transform.Translate(Vector3.forward * Time.deltaTime);
// // 		}
// // 		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,  0.43f )){
// // 		playerRigid.useGravity = false;
// // 		//transform.up = hit.normal;
		
// // 		transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
// // 		//transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
// // 	    //transform.position = hit.point;
// // 		//  Debug.Log("hit");
// // 		//transform.position = hit.point;
// // 		}
// // 		else{
// // 			// Debug.Log("me worked");
// // 			playerRigid.useGravity = true;
// // 			transform.localEulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0);
// // 			//transform.localRotation.eulerAngles.x = 0;
// // 			//transform.rotation = 
// // 			//transform.rotation = Quaternion.FromToRotation(transform.up, Vector3(0,0,0)) * transform.rotation;
// // 			// transform.rotation = Quaternion.FromToRotation(transform.down, target.normal) * transform.rotation;
// // 			// transform.rotation = Quaternion.FromToRotation(transform.forward, target.normal) * transform.rotation;
// // 		}
// // 	}