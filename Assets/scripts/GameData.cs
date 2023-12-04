using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string level;
    public int currentHealth; 
    public float[] position; 

    public GameData (PlayerController player){
        level = player.level; 
        currentHealth = player.GetComponent<PlayerHealth>().health;

        position = new float[3]; 
        position[0] = player.transform.position.x; 
        position[1] = player.transform.position.y; 
        position[2] = player.transform.position.z; 
        

    }
}
