using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10; 
    public int speed; 
    //public GameObject bloodEffect; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
             gameObject.SetActive(false); 
        }
    }

    public void TakeDamage(int damage){
        //Instantiate(bloodEffect, transform.position, Quaternion.identity); 
        health -= damage;
        Debug.Log("damage TAKEN !"); 
    }
}
