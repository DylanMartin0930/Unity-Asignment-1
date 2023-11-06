using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private int health = 10;
    private int MAX_HEALTH = 100; 
    void Update(){
        if (Input.GetKeyDown(KeyCode.F)){
            //damage(10);
        }
        if (Input.GetKeyDown(KeyCode.H)){
            //heal(10); 
        }
    }
    public void Damage(int damage){
        if (damage < 0){
            throw new System.ArgumentOutOfRangeException("cannot have negative damage");
        }
            this.health -=damage; 
    
    }
}
