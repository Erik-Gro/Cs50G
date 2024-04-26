using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Sphere : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject closestEnemyInDirection;
    public GameObject dummy;
    public Transform body;
    //public int tragectory  = 11;
    public float distance;
    public float closestDistance ; 
    void Start()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"||other.tag == "Spring")
        {
            if (enemies.Count==0){
                enemies.Add(other.gameObject);
            }
            for ( int i = enemies.Count-1; i >= 0; i--)
            {
                if (other.gameObject == enemies[i])
                {
                    return;
                }
            }
            enemies.Add(other.gameObject);
        }
       //FindClosesEnemy();
    }
       void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy"||other.tag == "Spring")
        {
            for ( int a = enemies.Count-1; a >= 0; a--)
            {
                if (other.gameObject == enemies[a])
                {
                    enemies.RemoveAt(a);
                }
            }
        }
        //FindClosesEnemy();
    }
    void Update()
    {
        
    }
    public GameObject FindClosesEnemy(){
        //  enemies.RemoveAll(item => item == null);
         //distance = 100f;
         closestEnemyInDirection = dummy;
         if(closestEnemyInDirection.tag == "Dummy"){
            closestDistance = 100f;
         }
         //if(enemies.Count==0)return;
         for ( int a = enemies.Count-1; a >= 0; a--)
    {
        if (enemies[a] == null )
            {
            enemies.RemoveAt(a);
            continue;
            }
        distance = Vector3.Distance(enemies[a].transform.position, body.transform.position);
        if (distance < closestDistance)
        {
            closestEnemyInDirection = enemies[a];
            closestDistance = distance;
        }
    }
        return closestEnemyInDirection;
    }
}

// for ( int a = enemies.Count-1; a >= 0; a--)
//             {
//                 if (enemies[a] == null )
//                 {
//                     enemies.RemoveAt(a);
//                 }
//                 if (distance < closestDistance)
//         {
//             closestEnemyInDirection = enemies[a];
//             closestDistance = distance;
//         }
    