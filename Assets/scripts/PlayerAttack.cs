using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeBtwAttack; 
    public float startTimeBtwAttack;
    public Transform attackPos; 
    public LayerMask whatIsEnemies;
    public float attackRange; 
    public int damage;
    public Animator animator; 
    

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }
    void Update(){
        if(timeBtwAttack <= 0){
            //then you can attack
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetTrigger("Attack"); 
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies); 
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            //timeBtwAttack = startTimeBtwAttack;
        }else{
            timeBtwAttack -= Time.deltaTime; 
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
