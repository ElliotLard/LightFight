using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	// How fast the player will move when they move.
	public float speed;

	// Gives us access to the RB2D, so we can move the player.
	private Rigidbody2D rb2d;
    public Gun gunType;
	public Transform firePoint;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
        gunType.transform.position = firePoint.position;
	}

	void Update()
	{
	}

	void FixedUpdate()
	{
		// Move with physics
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.velocity = (movement * speed);
		// Rotate to Face the Mouse
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
