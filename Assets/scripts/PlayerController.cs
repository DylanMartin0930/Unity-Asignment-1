using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    public Vector3 position;
    [SerializeField]public string level = "GrassForrest";
    public PlayerHealth currentHealth; 
    public float moveSpeed;
    private bool isMoving; 
    private Vector2 input; //vector2 holds 2 values; X & Y 
    private Animator animator;
    public LayerMask solidObjectsLayer; 
    public LayerMask interactablesLayer;
    public GameObject attackBubble;  
    public HealthBar healthbar; 
    // Start is called before the first frame update

    [SerializeField] private AudioSource moveSoundEffect; //for player steps
    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void HandleUpdate()
    {



        if (!isMoving)
        {
            //get user input
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical"); 
            
            //Debug.Log("this is input.x" + input.x);
            //Debug.Log("this is input.y" + input.y);




            if (input.x !=0) input.y = 0; //remove diagnoal movements

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y); 

                var targetPos = transform.position; 
                targetPos.x += input.x; 
                targetPos.y += input.y; 

                moveSoundEffect.Play();
                attackBubble.transform.position = new Vector2(targetPos.x, targetPos.y);

                if (IsWalkable(targetPos))
                {
                StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving); 



        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
      


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Desert");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("GrassForrest");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("DesertCity");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("MarsRiver");
        }
         if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Ocean Enviornment");
        }
     
    }

    void Interact(){
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY)"));
        var interactPos = transform.position + facingDir; 

        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f); 

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactablesLayer);
        if (collider != null){
            collider.GetComponent<Interactable>()?.Interact();
        }

    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true; 

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); 
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false; 
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactablesLayer) != null)
        {
            return false; 
        }
        return true; 
    }

        public void SavePlayer() {
        SaveSystem.SavePlayer(this); 
    }
    public void LoadPlayer(){
        GameData data = SaveSystem.LoadPlayer();
        
        level = data.level;
        currentHealth.health = data.currentHealth;
        healthbar.SetHealthBar(currentHealth.health); 

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position; 
    }
}
