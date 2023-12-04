using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider; 
    public PlayerHealth playerhealth; 

    public void SetMaxHealthBar(int health){
        slider.maxValue = health;
        slider.value = health; 
    }
    public void SetHealthBar(int health){
        slider.value = health; 
    }
    void Update(){
        slider.value = playerhealth.health;
    }
}
