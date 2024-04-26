using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    //[SerializeField] private GameObject HitArea;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject parent;
    // Start is called before the first frame update
    void Awake()
    {
        Enemy enemyComponent = parent.transform.GetComponent<Enemy>();
        if (enemyComponent != null)
{
    enemyComponent.enemies = enemies;
}
     
    }

    // Update is called once per frame
    void Update()
    {
        //parent.transform.GetComponent<Enemy>() = enemies;  
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
        if(other.tag == "Player")
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

    public List<GameObject> GiveObjectsInCollider()
{
    if (enemies.Count != 0)
    {
        return enemies;
    }
    return null;
}
}
