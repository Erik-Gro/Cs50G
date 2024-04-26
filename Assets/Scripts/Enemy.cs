using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Sphere     sphere;
    [SerializeField] private GameObject  dummy;
    [SerializeField] private Animator   animator;
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private Transform playerTransform;
    [SerializeField] private float chaseRadius = 5f; 
    [SerializeField] private float rotationSpeed = 3f; 
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private bool attacking = false;
    public List<GameObject> enemies = new List<GameObject>();
    private string anim = "idle";
    private string prevAnim = "idle";
    [SerializeField] private float count = 0f;
    public Player script;
    public bool playAttackAnim = false;
    public bool Attacked = false;
    public GameObject playerObject;
    public GameObject sphereObj;
    void Awake()
    {
        // //Player script = other.gameObject.GetComponent<Player>();
        // string attackAnimationClipName = "attack";
        // // Get the attack animation clip from the animator controller
        // AnimationClip clip = System.Array.Find(animator.runtimeAnimatorController.animationClips, c => c.name == attackAnimationClipName);

        // if (clip != null)
        // {
        //     float attackAnimationLength = clip.length;
        //     Debug.Log("Attack animation length: " + attackAnimationLength);
        // }
        // else
        // {
        //     Debug.LogError("Attack animation clip not found!");
        // }
        
    }
        //hitArea = HitAreaObject.gameObject.GetComponent<HitArea>();

    void Start(){
        sphereObj = GameObject.Find("SphereItself");
        playerObject = GameObject.FindWithTag("Player");
        script = playerObject.GetComponent<Player>();
        sphere = sphereObj.GetComponent<Sphere>();
        //Debug.Log(script);
    }
    private void Update(){
        if (enemies.Count!>0){
            attacking= true;
            playAttackAnim = true;
        }
        else{
        attacking = false;
        playAttackAnim = false;
        count = 0f;
        }
        if(count>=1.2f&&attacking){
            count %= 1.2f;
            Attacked = false;
        }
        else if(count<=1.2f&&attacking){
            count += Time.deltaTime;
        }
        if(count>=0.48f&&!Attacked){
            Attack();
            Attacked = true;
        }
    }
    private void FixedUpdate()
    {
        if(attacking){
        return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

        if (distanceToPlayer <= chaseRadius)
{
    Vector3 direction = (playerObject.transform.position - transform.position).normalized;

    Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

    rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

    Vector3 movement = direction * movementSpeed * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + movement);
     anim = "jog";
}
else{
    anim = "idle";
}
    }
    void LateUpdate(){
    if(playAttackAnim){
    animator.Play("attack");
    anim = "attack";
    playAttackAnim = false;
    return;  
    }
    setAndReset();
    }


     void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player"){
            
            // Player script = other.gameObject.GetComponent<Player>();
            if (script.attaking)

            {
                script.CanPerformAttack = true;
                script.attaking = false;
                script.attack = false;
                script.time = 0f;
                script.jumpSpeed = 6.8f;
                //sphere.closestEnemyInDirection = dummy;
                Destroy(gameObject);
                return;
            }  
            if (script.invicibility <= 0){
                script.getDamage();
            }
        }
    }
     void Attack (){
        if (script.invicibility <= 0){
                script.getDamage();
            }
    }
    private void setAndReset()
    {
    animator.ResetTrigger(prevAnim);
    animator.SetTrigger(anim);
    prevAnim = anim;
}
}

