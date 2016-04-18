using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	// How fast the player will move when they move.
	public float speed;

	// Gives us access to the RB2D, so we can move the player.
	private Rigidbody2D rb2d;

	public GameObject shot;
	public Transform firePoint;
	public float fireRate;
	private float nextFire;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Input.GetMouseButton(0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, firePoint.position, firePoint.rotation);
		}
	}

	void FixedUpdate()
	{
		// Move with physics
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);

		// Rotate to Face the Mouse
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
		}
	}
}
