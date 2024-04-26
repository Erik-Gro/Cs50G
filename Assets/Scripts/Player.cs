
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
 
/* Comment section
 
Vector3(47.519001,-113.843002,33.6469994) 0.08800001
Vector3(45.7210007,-114.537003,31.7460003)
Vector3(0.100000001,-53.3300018,-3.5999999)
Vector3(-0.0489999987,-97.5630035,-15.1850004) second panel
 
*/
 
public class Player : MonoBehaviour 
{
    public bool  CanPerformAttack = false;
    public float  invicibility = 0f;
    public bool  attaking = false;
    public float backforce = 0;
    public float jumpSpeed = 0;
    public float time;
    public GameObject objectPrefab;
    public GameObject Bullet;
    public GameObject Map;
    public GameObject BulletStart;
    public float downforce = 0;
    public float forwardforce = 14f;
    public bool tookDamage = false;
    public bool Move = false;
    public bool Jump = false;
    public bool attack = false;
    public bool hasForce = false;
    public float      speed;
    [SerializeField] private GameObject AttackTarget;
    [SerializeField] private GameObject AttackRange;
    [SerializeField] private Rigidbody  playerRigid; 
    [SerializeField] private Animator   playerAnim;
    [SerializeField] private Camera     cam;
    [SerializeField] private float      transitionTimer;
    [SerializeField] private float      turnSpeed;
    [SerializeField] private bool       seekingRing;
    [SerializeField] private bool       moveForward = false;
    [SerializeField] private GameObject ModelChild;
    [SerializeField] private float invincibilityCount=0.3f;
    [SerializeField] private bool grounded = false;
    [SerializeField] private AudioClip GunShoot;
    [SerializeField] private AudioClip GunReload;
    private  float takenDamage = 0f;
    private bool WasVisible = true;
    private RaycastHit hit;
    private bool once = false;
    private Vector3 previousPosition;
    private Vector3 previousYposition;
    private float count = 1.166667f;
    private string anim = "idle";
    private string prevAnim = "idle";
    private bool shoot = false;
    private bool reloaded = true;
    private bool playShootAnim = false;
    public float attackTime;
    private float targetModulo = 1.166667f;
    private Quaternion originalRotation;
    public int rings =0;
    private TextMeshProUGUI textElement;
    void Start() {
        originalRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        GameObject textObject = GameObject.Find("Text (TMP)");
        textElement = textObject.GetComponent<TextMeshProUGUI>();
    }
 
    void Update()
    {
         Move = false;
         shoot = false;
         Jump = false;
        if(tookDamage||attack||hasForce||seekingRing){
            return;
        }
        if (Input.GetKey(KeyCode.X)){
            seekingRing = true;
        }
        if (Input.GetKey(KeyCode.Z)){
            shoot = true;
        }
        if (Input.GetKey(KeyCode.Space) )
        {
            Jump = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move = true;
        }
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
 
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
 
        if (Input.GetKeyDown(KeyCode.Space) && CanPerformAttack)
        {
            attack = true;
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(transform.forward), Color.yellow);
    }
 
    void FixedUpdate()
    {
        playerRigid.velocity = Vector3.zero;
        shootFunc();
        if (giveTrajectoryFOrce()){
            return;
        }
         if (decrementTakenDamage()){
            return;
        }
        if (seekingRing)
        {
            if(seekRing()){
                return;
            }
        }
        if(attack){
            findTarget();
            return;
        }
        move();
        decrementInvincibility();
        previousYposition = transform.position;
        Debug.DrawRay(transform.position, new Vector3(0, -0.11f, 0), Color.yellow);
        jumpSpeed -= jumpSpeed*Time.fixedDeltaTime;
        playerRigid.velocity += new Vector3(0,jumpSpeed,0);
        playerRigid.velocity += transform.forward * speed * Time.fixedDeltaTime;
    }

    public void LateUpdate(){
    if(playShootAnim){
    playerAnim.Play("shoot");
    return;  
    }
    if(tookDamage){
    setAndReset("layin");
    return; 
    }
    if(!grounded){
    playerAnim.Play("falling");
    //setAndReset("falling");
    return; 
    }
    if(speed==0){
    setAndReset("idle");    
    return; 
    }
    if(speed>0&&speed<=90){
    setAndReset("walk");
    return; 
    }
    if(speed>90&&speed<=200){
    setAndReset("jog");
    return; 
    }
    if(speed>200){
    setAndReset("run");
    return;  
    }
}

public void shootFunc(){
     if(count < targetModulo){
        count += Time.fixedDeltaTime;
        playShootAnim = false;
    }
         if (count >= targetModulo && !reloaded){
        Debug.Log("1");
        count= targetModulo;
        reloaded = true;
        SoundManager.instance.PlaySoundFXClip(GunReload,transform,0.5f);
    }
    if (count >= targetModulo && shoot&& reloaded)
        {
            Debug.Log("2");
            count %= targetModulo;
            SoundManager.instance.PlaySoundFXClip(GunShoot,transform,0.1f);
            GameObject bullet = Instantiate(Bullet, BulletStart.transform.position, BulletStart.transform.rotation);
            Transform bulletChild = bullet.transform.Find("BulletCollider");
            bulletChild.GetComponent<BulletCollider>().owner = "Player";
            playShootAnim = true;
            reloaded = false;
        }
}


    private void setAndReset(string nextanim)
    {
    playerAnim.ResetTrigger(anim);
    playerAnim.SetTrigger(nextanim);
    anim = nextanim;
}

    public void findTarget(){
            //CanPerformAttack = false;
            transitionTimer = 0f;
            Sphere sp = AttackRange.GetComponent<Sphere>();
            AttackTarget = sp.FindClosesEnemy();
            //time += Time.fixedDeltaTime*5.2f;
            if (AttackTarget.tag != "Dummy"){
                attaking = true;
                transform.position = Vector3.Lerp(transform.position, AttackTarget.transform.position, 0.5f);
            }
            else{
                attack = false;
            }
    }
    public void move(){
        //Debug.Log(Vector3.Angle(hit.normal, Vector3.up));
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,  0.2f )&&hit.collider.gameObject.tag == "Map")
        {
                CanPerformAttack = false;
                if(jumpSpeed<=4f){
                   jumpSpeed = 0;
                }
                grounded = true;
                if (speed>=360 || (Vector3.Angle(hit.normal, Vector3.up)<60)){
                    transform.position = hit.point + (transform.TransformDirection(Vector3.up) * 0.08800001f);
                    transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                }
                else if(Vector3.Angle(hit.normal, Vector3.up)>45) {
                Vector3 negativeVelocity = new Vector3(0f, -4f, 0f);
                playerRigid.velocity += negativeVelocity;
                speed = 0;
                } 
                if(Jump)
                {
                    Quaternion newRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
                    transform.rotation = newRotation;
                    //Jump = false;
                    jumpSpeed = 6.8f;
                }
                if(Move){
            if(previousYposition.y<transform.position.y){
               speed += 25 * Time.fixedDeltaTime; 
            } 
            if(previousYposition.y>transform.position.y){
               speed += 160 * Time.fixedDeltaTime;
            } 
            if(previousYposition.y==transform.position.y){
               speed += 75 * Time.fixedDeltaTime;
            }
            if(previousYposition==transform.position &&speed>75){
                speed = 0;
            }
            speed = (speed >= 460) ? 460 : speed; 
        }
        else{
            speed = 0;
        }     
    }

        else if (hit.collider == null || hit.collider.gameObject.tag != "Map")
        {
            grounded= false;
            //Jump = false;
            CanPerformAttack = true;
            Vector3 negativeVelocity = new Vector3(0f, -4f, 0f);
            playerRigid.velocity += negativeVelocity;
            Quaternion currentRotation = transform.rotation;

        Quaternion xzRotation = Quaternion.Euler(originalRotation.eulerAngles.x, currentRotation.eulerAngles.y, originalRotation.eulerAngles.z);
        Quaternion newRotation = Quaternion.Lerp(currentRotation, xzRotation, 3f * Time.deltaTime);

        newRotation.eulerAngles = new Vector3(newRotation.eulerAngles.x, currentRotation.eulerAngles.y, newRotation.eulerAngles.z);

        transform.rotation = newRotation;

        if (Quaternion.Angle(transform.rotation, xzRotation) <= 0.1f)
        {
            transform.rotation = xzRotation;
        }
            // transform.localEulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0);
             if (Move){
             speed = 90;
        }
        else {
            speed = 0;
        }   
    }
}
    public bool giveTrajectoryFOrce(){
            hasForce = false;
            if (forwardforce >0 ){
                forwardforce -= Time.fixedDeltaTime;
                playerRigid.velocity += transform.forward  *  Time.fixedDeltaTime *300;
                hasForce = true; 
            }
            else{
                forwardforce = 0;
            }
            if (backforce >0){
                backforce -= Time.fixedDeltaTime;
                playerRigid.velocity +=  transform.forward * -1   * Time.fixedDeltaTime*300;
                hasForce = true;
            }
            else{
                backforce=0;
            }
            if (downforce >0){
                downforce -= Time.fixedDeltaTime;
                playerRigid.velocity +=  transform.up * -1  * Time.fixedDeltaTime *300;
                hasForce = true;
            }
            else{
                downforce=0;
            }
            if(hasForce){
                grounded = false;
            }
            return hasForce;
    }
    public void decrementInvincibility(){
            if (invicibility >0f ){
                invicibility -= Time.fixedDeltaTime; 
                invincibilityCount += Time.fixedDeltaTime;
            
            if (invincibilityCount >= 0.15f ) {
            invincibilityCount =  invincibilityCount % 0.15f ;
            if (WasVisible) {
                WasVisible = false;
            }
            else{
                WasVisible = true;
            }
        }
        }
            else{
                invicibility = 0f;
                invincibilityCount=0.3f;
                WasVisible = true; 
            }
            ModelChild.SetActive(WasVisible); 
    }

    public bool decrementTakenDamage(){
        if (takenDamage >0 ){
                takenDamage -= Time.fixedDeltaTime;
                tookDamage = true;
                return true; 
            }
            else{
                tookDamage=false;
                return false;
            }
    }
    public void getDamage(){
                jumpSpeed  = 0;
                backforce = 0.6f;
                downforce = 0.6f;
                invicibility = 5f;
                tookDamage = true;
                takenDamage = 0.2f;
                //Move = false;
                DropRings();
    }
    public bool seekRing(){
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,  1f, Physics.DefaultRaycastLayers,QueryTriggerInteraction.Collide ))
            {
                if (hit.collider.tag == "Ring")
                {
                    transform.position = hit.transform.position;
                    Vector3 targetForward = hit.collider.transform.parent.forward;
                    Transform parentTransform = hit.collider.transform.parent;
                    RingHolder parentScript = parentTransform.GetComponent<RingHolder>();
                    Quaternion targetRotation;
                    Vector3 playerForward = transform.forward;
                    float angleWithForward = Vector3.Angle(playerForward, targetForward);
                    float angleWithBackward = Vector3.Angle(playerForward, -targetForward);
                    if (angleWithForward < angleWithBackward)
                {
                    targetRotation = parentTransform.rotation;
                    transform.rotation = targetRotation;
                    return true;
                }
                else
                {
                    targetRotation = parentTransform.rotation;
                    transform.rotation = targetRotation;
                    transform.Rotate(0f, 180f, 0f);
                    return true;
                }
                }
                else
                {
                    seekingRing = false;
                    return false;
                }
            }
            else
                {
                    seekingRing = false;
                    return false;
                }
    }
     public void DropRings(){
        float rotate = 0f;
        if(rings==0){
            SceneManager.LoadScene("Begin");
        }
        int dropingRings = (rings > 20) ? 20 : rings;
        rings -= dropingRings;
        textElement.text = "rings : " + rings.ToString();
        for ( int a = dropingRings; a > 0; a--)
        {
         GameObject spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
         spawnedObject.GetComponent<DroppingRing>().map = Map;
         spawnedObject.transform.Rotate(0f, rotate, 0f);
         Rigidbody spawnedRigidbody = spawnedObject.GetComponent<Rigidbody>();
         spawnedRigidbody.AddForce(spawnedObject.transform.forward * 2f, ForceMode.Impulse);
         rotate += 360/dropingRings;
        }
    }
//     void OnCollisionEnter(Collision collision)
// {
//     if (collision.gameObject.tag == "Ring")
//     {
//         rings++;
//     }
// }
}