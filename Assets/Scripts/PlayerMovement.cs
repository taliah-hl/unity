using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float PlayersMovementSPeed=10.0f; //this is players movement speed.
    
    [SerializeField]

    //private float _playersMovementDirection = 0.0f; //this will give the direction of the players movement.   
    public float PlayerJumpingForce = 10.0f; //this is players jumping force.
    private Rigidbody2D _playersRigidBody; //reference of the players rigid body.
    private Animator animator;

    private Vector2 _moveInput;
    private float dir_x = 0f;
    private SpriteRenderer sprite;


    void Awake(){

        
    }
    // private void OnEnable(){
    //     _playerActions.Player.Enable(); //Player is name of map
    // }

    // private void OnDisable(){
    //     _playerActions.Player.Disable();//Player is name of map
    // }
    private void Start()
    {
       _playersRigidBody = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       sprite = GetComponent<SpriteRenderer>();

       
        
    }
   


    private void FixedUpdate()
    {
    }

     private void PlayerJump()
    {
        // float dir_x = Input.GetAxis("Horizontal");
        // _playersRigidBody.velocity = new Vector2(dir_x)
       // Debug.Log("Jump push!");
    }

    // Update is called once per frame
    void Update()
    {
        dir_x = Input.GetAxisRaw("Horizontal");
        _playersRigidBody.velocity = new Vector2(dir_x * PlayersMovementSPeed, _playersRigidBody.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {

            _playersRigidBody.velocity = new Vector2(dir_x, PlayerJumpingForce);
        }
        AnimationUpdate();
        
    }

    void AnimationUpdate(){
        if(dir_x >0){
            animator.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if(dir_x <0){
            animator.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else{
            animator.SetBool("isRunning", false);
        }
    }
}
