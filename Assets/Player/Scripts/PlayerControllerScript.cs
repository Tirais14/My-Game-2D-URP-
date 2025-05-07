using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float movementSpeed = 1f;
    private Vector2 direction;
    public Rigidbody2D rb;
	public Animator playerController;
	public SpriteRenderer characterSprite;
	// Start is called before the first frame update
	void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
		direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
	}

	void FixedUpdate()
	{
		Moving();
	}

	private void Moving()
	{
		if (direction.x != 0 && direction.y != 0)
		{
			direction.Normalize();
		}
		playerController.SetFloat("Horizontal", direction.x);
		playerController.SetFloat("Vertical", direction.y);
		playerController.SetFloat("MovementSpeed", direction.sqrMagnitude);
		rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
	}
}
