using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
	private Vector2 direction;
	[SerializeField] private float movementSpeed = 1f;
    [SerializeField] private Rigidbody2D rb;
	[SerializeField] private Animator playerController;
	[SerializeField] private SpriteRenderer characterSprite;
	[SerializeField] private Sprite[] mainCharacterSprites;
	private enum characterDirection : byte
	{
		Left = 0,
		Right,
		Back,
		Forward
	}

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
		if (direction.x > 0)
		{ characterSprite.sprite = mainCharacterSprites[(byte)characterDirection.Right]; }
		else if (direction.x < 0)
		{ characterSprite.sprite = mainCharacterSprites[(byte)characterDirection.Left]; }
		else if (direction.y > 0)
		{ characterSprite.sprite = mainCharacterSprites[(byte)characterDirection.Forward]; }
		else if (direction.y < 0)
		{ characterSprite.sprite = mainCharacterSprites[(byte)characterDirection.Back]; }
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
