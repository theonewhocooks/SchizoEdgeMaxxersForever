using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
	private int damage = 5;
	public GameObject enemy;
	public AudioSource audioSource;

    public AudioClip bonesAudioClip;

	public int health;
	public KeyCode jumpkey = KeyCode.Space;
	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	bool readyToJump;
	public float playerHeight;
	public LayerMask whatIsGround;
	bool grounded;

	public float moveSpeed;

	public Transform orientation;

	float horizontalInput;
	float verticalInput;
	Vector3 moveDirection;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		ResetJump();
	}

    private void Update()
    {
		MyInput();
    }

    private void FixedUpdate()
    {
		MovePlayer();
    }

    private void MyInput()
    {
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
		if(Input.GetKey(jumpkey) && readyToJump && grounded)
		{
			readyToJump = false;

			Jump();

			Invoke(nameof(ResetJump), jumpCooldown);
		}
    }

	void MovePlayer()
	{
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		if(grounded)
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

		else if(!grounded)
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

	}

	private void Jump()
	{
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

	}
	private void ResetJump()
	{
		readyToJump = true;
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
		{
			TakeDamage();
			audioSource.PlayOneShot(bonesAudioClip, 1);
		}
    }

    public void TakeDamage()
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyPlayer), .5f);
    }

	private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}