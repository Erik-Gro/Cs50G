                    //own facing direction deterination betweeen objects
                    // float compare1 =  (parentScript.minYrotation -90) * 0.01f * 90;
                    // float compare2 =  (parentScript.maxYrotation +90) * 0.01f * 90;
                    // Debug.Log(compare1+" "+compare2 );
                    //if (parentScript.minYrotation <= compare1 && parentScript.maxYrotation >= compare2)
                    // if (parentScript.minYrotation <= transform.rotation.eulerAngles.y && parentScript.maxYrotation >= transform.rotation.eulerAngles.y)
                    // {
                    //       targetRotation = parentTransform.rotation;
                    //       transform.rotation = targetRotation;
                    // }
                    // else{
                    //      targetRotation = parentTransform.rotation;
                    //      transform.rotation = targetRotation;
                    //      transform.Rotate(0f, 180f, 0f);
                    // }

                    
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq;
 
// /* Comment section
 
// Vector3(47.519001,-113.843002,33.6469994) 0.08800001
// Vector3(45.7210007,-114.537003,31.7460003)
// Vector3(0.100000001,-53.3300018,-3.5999999)
// Vector3(-0.0489999987,-97.5630035,-15.1850004) second panel
 
// */
 
// public class Player : MonoBehaviour 
// {
//     public bool  CanPerformAttack = false;
//     public float  invicibility = 0f;
//     public bool  attaking;
//     public float backforce = 0;
//     public float jumpSpeed = 0;
//     public float time;
//     public GameObject objectPrefab;
//     public GameObject Map;
//     public float downforce = 0;
//     public float forwardforce = 14f;
//     public bool tookDamage = false;
//     //public int AffectedByForce = 0;
//     [SerializeField] private GameObject AttackTarget;
//     [SerializeField] private GameObject AttackRange;
//     [SerializeField] private Rigidbody  playerRigid; 
//     [SerializeField] private Animator   playerAnim;
//     [SerializeField] private Vector3    initialPosition;
//     [SerializeField] private Vector3    initialRotation;
//     [SerializeField] private Camera     cam;
//     [SerializeField] private float      transitionTimer;
//     [SerializeField] private float      turnSpeed;
//     [SerializeField] private float      speed;
//     [SerializeField] private bool       seekingRing;
//     private RaycastHit hit;
//     private bool once = false;
//     private Vector3 previousPosition;
//     private float previousYposition;
//     private bool moveForward = false;
//     void Start() {
//         previousYposition = transform.position.y;
//     }
 
//     void Update()
//     {
//         //Debug.Log(transform.rotation.eulerAngles.x);
//         if (Input.GetKey(KeyCode.X)){
//             seekingRing = true;
//         }
//         if (attaking)
//         {
//             time += Time.deltaTime;
//             transform.position = Vector3.Lerp(transform.position, AttackTarget.transform.position, time);
//             return;
//         }
//         if(tookDamage)return;
//         if (Input.GetKeyDown(KeyCode.W))
//         {
//             playerAnim.ResetTrigger("idle");
//             playerAnim.SetTrigger("jog");
//         }
 
//         if (Input.GetKeyUp(KeyCode.W))
//         {
//             playerAnim.ResetTrigger("jog");
//             playerAnim.SetTrigger("idle");
//         }
 
//         if (Input.GetKey(KeyCode.A))
//             transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
 
//         if (Input.GetKey(KeyCode.D))
//             transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
 
//         if (Input.GetKeyDown(KeyCode.Space) && CanPerformAttack)
//         {
//             CanPerformAttack = false;
//             transitionTimer = 0f;
//             Sphere sp = AttackRange.GetComponent<Sphere>();
//             AttackTarget = sp.FindClosesEnemy();
 
//             if (AttackTarget.tag != "Dummy")
//                 attaking = true;
//         }
//         Debug.DrawRay(transform.position, transform.TransformDirection(transform.forward), Color.yellow);
//     }
 
//     void FixedUpdate()
//     {
//         //Debug.Log(transform.rotation.eulerAngles.x);
//         playerRigid.velocity = Vector3.zero;
//         if (tookDamage){
//             if(forceBack()){
//                 return;
//             }     
//         }
//         // if(forwardforce > 0 || backforce > 0 ){
//         //     if (forwardforce <=0 ){
//         //         forwardforce = 0;
//         //     }
//         //     else{
//         //         forwardforce -= Time.fixedDeltaTime;
//         //     }
//         //     if (backforce >=0){
//         //         backforce -= Time.fixedDeltaTime;
//         //         downforce -= Time.fixedDeltaTime;
//         //     }
//         //     else{
//         //         backforce=0;
//         //         downforce=0;
//         //     }
//         //     playerRigid.velocity += transform.forward * 50 * forwardforce * Time.fixedDeltaTime; 
//         //     playerRigid.velocity +=  transform.forward * -1 *backforce  * Time.fixedDeltaTime*100;
//         //     playerRigid.velocity +=  transform.up * -1 * downforce * Time.fixedDeltaTime *100;
//         //     return;
//         // }   
//         if (seekingRing)
//         {
//             if(seekRing()){
//                 return;
//             }
//         }

//         if(attaking){
//             return;
//         }
 
//         if(invicibility > 0)
//         {
//             decrementInvincibility();
//         }

//         if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,  0.1f )&&hit.collider.gameObject.tag == "Map")
//         {
//                 CanPerformAttack = false;
//                 jumpSpeed = 0;
//                 if (speed>=360 || (Vector3.Angle(hit.normal, Vector3.up)<45)){
//                 transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
//                 }
//                 else if(Vector3.Angle(hit.normal, Vector3.up)>75) {
//                 transform.localEulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0);
//                 } 
//                 if(Input.GetKey(KeyCode.Space))
//                 {
//                     jumpSpeed = 6.8f;
//                 }
//         }

//         else if (hit.collider == null || hit.collider.gameObject.tag != "Map")
//         {
//             CanPerformAttack = true;
//             Vector3 negativeVelocity = new Vector3(0f, -4f, 0f);
//             playerRigid.velocity += negativeVelocity;
//             transform.localEulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0);
//         }
//         Debug.DrawRay(transform.position, new Vector3(0, -0.1f, 0), Color.yellow);
//         if(Input.GetKey(KeyCode.W)){
//             if(previousYposition<transform.position.y){
//                speed += 25 * Time.deltaTime;
//             } 
//             if(previousYposition>transform.position.y){
//                speed += 160 * Time.deltaTime;; 
//             } 
//             if(previousYposition==transform.position.y){
//                speed += 75 * Time.deltaTime;
//             }
//             previousYposition = transform.position.y;
//             speed = (speed >= 460) ? 460 : speed;
//         }
//         else{
//              speed = 0;
//         }
//         jumpSpeed -= jumpSpeed*Time.fixedDeltaTime;
//         playerRigid.velocity += new Vector3(0,jumpSpeed,0);
//         playerRigid.velocity += transform.forward * speed * Time.fixedDeltaTime;
//     }

//     public void giveTrajectoryFOrce(){
//         // if(forwardforce > 0 || backforce > 0 ){
//         //     if (forwardforce <=0 ){
//         //         forwardforce = 0;
//         //     }
//         //     else{
//         //         forwardforce -= Time.fixedDeltaTime;
//         //     }
//         //     if (backforce >=0){
//         //         backforce -= Time.fixedDeltaTime;
//         //     }
//         //     else{
//         //         backforce=0;
//         //     }
//         //     if (downforce >=0){
//         //         downforce -= Time.fixedDeltaTime;
//         //     }
//         //     else{
//         //         downforce=0;
//         //     }
//         //     playerRigid.velocity += transform.forward * 50 * forwardforce * Time.fixedDeltaTime; 
//         //     playerRigid.velocity +=  transform.forward * -1 *backforce  * Time.fixedDeltaTime*100;
//         //     playerRigid.velocity +=  transform.up * -1 * downforce * Time.fixedDeltaTime *100;
//         // } 
//     }
//     public bool forceBack(){
//             if (backforce >=0){
//                 playerAnim.SetTrigger("layin");
//                 backforce -= Time.fixedDeltaTime;
//                 downforce -= Time.fixedDeltaTime;
//                 giveTrajectoryFOrce();
//                 playerRigid.velocity +=  transform.forward * -1 *backforce  * Time.fixedDeltaTime*100;
//                 playerRigid.velocity +=  transform.up * -1 * downforce * Time.fixedDeltaTime *100;
//                 return false;
//             }
//             else{
//                 backforce=0;
//                 downforce=0;
//                 tookDamage=false;
//                 playerAnim.ResetTrigger("layin");
//                 playerAnim.SetTrigger("idle");
//                 giveTrajectoryFOrce();
//                 playerRigid.velocity +=  transform.forward * -1 *backforce  * Time.fixedDeltaTime*100;
//                 playerRigid.velocity +=  transform.up * -1 * downforce * Time.fixedDeltaTime *100;
//                 return true;
//             }
//     }
//     public void decrementInvincibility(){
//             if (invicibility <=0 ){
//                 invicibility = 0;
//             }
//             else invicibility -= Time.fixedDeltaTime;
//     }
//     public bool seekRing(){
//         if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,  1f, Physics.DefaultRaycastLayers,QueryTriggerInteraction.Collide ))
//             {
//                 if (hit.collider.tag == "Ring")
//                 {
//                     transform.position = hit.transform.position;
//                     Vector3 targetForward = hit.collider.transform.parent.forward;
//                     Transform parentTransform = hit.collider.transform.parent;
//                     RingHolder parentScript = parentTransform.GetComponent<RingHolder>();
//                     Quaternion targetRotation;
//                     Vector3 playerForward = transform.forward;
//                     float angleWithForward = Vector3.Angle(playerForward, targetForward);
//                     float angleWithBackward = Vector3.Angle(playerForward, -targetForward);
//                     if (angleWithForward < angleWithBackward)
//                 {
//                     targetRotation = parentTransform.rotation;
//                     transform.rotation = targetRotation;
//                     return true;
//                 }
//                 else
//                 {
//                     targetRotation = parentTransform.rotation;
//                     transform.rotation = targetRotation;
//                     transform.Rotate(0f, 180f, 0f);
//                     return true;
//                 }
//                 }
//                 else
//                 {
//                     seekingRing = false;
//                     return false;
//                 }
//             }
//             else
//                 {
//                     seekingRing = false;
//                     return false;
//                 }
//     }
//      public void DropRings(){
//         float rotate = 0f;
//         for ( int a = 20; a >= 0; a--)
//         {
//          GameObject spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
//          spawnedObject.GetComponent<DroppingRing>().map = Map;
//          spawnedObject.transform.Rotate(0f, rotate, 0f);
//          Rigidbody spawnedRigidbody = spawnedObject.GetComponent<Rigidbody>();
//          spawnedRigidbody.AddForce(spawnedObject.transform.forward * 2f, ForceMode.Impulse);
//          rotate += 20f;
//         }
//     }
// }

// if (forwardforce >0 ){
//                 Debug.Log("1");
//                 forwardforce = 0;
//                 playerRigid.velocity += transform.forward  * forwardforce * Time.fixedDeltaTime*100; 
//             }
//             else{
//                 forwardforce -= Time.fixedDeltaTime;
//             }
//             if (backforce >0){
//                 Debug.Log("2");
//                 backforce -= Time.fixedDeltaTime;
//                 playerRigid.velocity +=  transform.forward * -1 *backforce  * Time.fixedDeltaTime*100;
//             }
//             else{
//                 backforce=0;
//             }
//             if (downforce >0){
//                 Debug.Log("3");
//                 downforce -= Time.fixedDeltaTime;
//                 playerRigid.velocity +=  transform.up * -1 * downforce * Time.fixedDeltaTime *100;
//             }
//             else{
//                 downforce=0;
//             }
//             // playerRigid.velocity += transform.forward  * forwardforce * Time.fixedDeltaTime*100; 
//             // playerRigid.velocity +=  transform.forward * -1 *backforce  * Time.fixedDeltaTime*100;
//             // playerRigid.velocity +=  transform.up * -1 * downforce * Time.fixedDeltaTime *100;