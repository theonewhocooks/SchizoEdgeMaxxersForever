using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

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
    }

	void MovePlayer()
	{
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);

	}

}