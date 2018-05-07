using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private static  Player instance;
	   public static Player Instance
    {
        get
        {
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<Player>();
			}
            return instance;
        }
    }
	private Animator myAnimator;
	[SerializeField]
	private Transform knifePosition;
	[SerializeField]
	private float movementSpeed;
	private bool facingRight;
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	[SerializeField]
	private bool airControl;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private GameObject knifePrefab;
    [SerializeField]
    private int health;
    private float nextFire;
    [SerializeField]
    private float fireRate;
    public SimpleHealthBar Player1;
    public Rigidbody2D MyRigidbody{ get; set; } // Properties can be accessed from other places later
	public bool Attack { get; set; }
	public bool Slide { get; set; }
	public bool Jump { get; set; }
	public bool OnGround { get; set; }

 
    void Start () {
		facingRight = true;
		MyRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>(); // needed for attacking
	}
	
	void Update()
	{
		HandleInput();
	}
	void FixedUpdate () {
		OnGround = IsGrounded();

		float horizontal = Input.GetAxis("Horizontal");
		HandleMovement(horizontal);
		Flip(horizontal);
		HandleLayers();
	}

	private void HandleMovement(float horizontal)
	{
		if(MyRigidbody.velocity.y < 0)
		{
			myAnimator.SetBool("land", true);
		}
		if(!Attack && !Slide && (OnGround || airControl))
		{
			MyRigidbody.velocity = new Vector2(horizontal * movementSpeed, MyRigidbody.velocity.y);
		}
		if(Jump && MyRigidbody.velocity.y == 0)
		{
			MyRigidbody.AddForce(new Vector2(0, jumpForce));
		}

		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

	}

	private void Flip(float horizontal)
	{
		if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private void HandleInput()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			myAnimator.SetTrigger("jump");
		}
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			myAnimator.SetTrigger("attack");
		}
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			myAnimator.SetTrigger("slide");
		}
		if(Input.GetKeyDown(KeyCode.V))
		{
			myAnimator.SetTrigger("throw");
			ThrowKnife(0);
		}
	}

	private bool IsGrounded()
	{
		if(MyRigidbody.velocity.y <= 0)
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++)
				{
					if(colliders[i].gameObject != gameObject)
					{
						return true;
					}
				}
			}
			
		}
		return false;
	}
	private void HandleLayers()
	{
		if(!OnGround)
		{
			myAnimator.SetLayerWeight(1,1);
		}
		else{
			myAnimator.SetLayerWeight(1,0);
		}
	}
	// this is to know which direction we will throw the knife
	public void ThrowKnife(int value)
	{// this enables us t throw one knife at a time
		if((!OnGround && value == 1 || OnGround && value == 0) && Time.time > nextFire)
		{
			if(facingRight)
			{// intantiates knife at player position
				GameObject temp = (GameObject)Instantiate(knifePrefab,knifePosition.position,Quaternion.Euler(new Vector3(0,0,-90)));// added rotation by Euler
				temp.GetComponent<Knife>().Initialize(Vector2.right);
			}
			else
			{
				GameObject temp = (GameObject)Instantiate(knifePrefab,transform.position,Quaternion.Euler(new Vector3(0,0,90)));
				temp.GetComponent<Knife>().Initialize(Vector2.left);
			}
            nextFire = Time.time + fireRate;
        }
	
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        Player1.UpdateBar(health, 10);
        Debug.Log(health);
    }

    public void HealNinja()
    {
        if(health <= 5)
        {
            health += 5;
        }
        else
        {
            health = 10;
        }
        
        Player1.UpdateBar(health, 10);
    }
}
