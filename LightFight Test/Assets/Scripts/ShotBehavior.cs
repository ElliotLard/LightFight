using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
	}

	// Deletes upon hitting wall
	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.tag == "Border")
			Destroy (gameObject);

		if (otherObj.gameObject.tag == "Mirror")
        {
            /* r = i−2(i·n)n
             * Source: http://stanford.io/1zco8xk
             * where n is the vector perpendicular to the mirror,
             * r is the vector exiting the mirror,
             * and i is the vector hitting the mirror
             */
            Vector3 enterVelocity = rb2d.velocity; // n
            Vector3 exitVelocity = new Vector3(0,0,0); // r
            Quaternion rotation = Quaternion.Euler(exitVelocity);
            Destroy(gameObject);
            ContactPoint2D contactPoint = otherObj.contacts[0];
            Instantiate(gameObject, contactPoint.point, gameObject.transform.rotation);
            /*
             * As of right now, they are colliding constantly with the mirror
             * once they hit it. That's bad. However that doens't explain why they
             * don't move even if they're sent to the origin.
             */
        }
	}


}
