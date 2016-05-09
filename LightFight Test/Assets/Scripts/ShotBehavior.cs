using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public float speed;     // The speed that the bullet will move
    public float minLiving; // How long it must exist until it can reflect.
    public int damage; // how much damage a shot will do and Damn i need to extend this class.

    private bool isLive;    // Is able to reflect.
    private float timeLive; // In-game time when the bullet will be alive.
	private Rigidbody2D rb2d;
	

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
        timeLive = Time.time; // + minLiving;
        Physics2D.IgnoreLayerCollision(8, 8); // This means bullets can't touch bullets.
    }

    void Update()
    {
        if (Time.time <= timeLive)
            isLive = false; // "Live" basically means allowed to reflect.
        else
            isLive = true;

        if (rb2d.velocity.magnitude < .5) Destroy(gameObject); // Temporary line for Testing Shotgun Shells
    }

	// How a shot will handle interaction with each material.
	void OnCollisionEnter2D(Collision2D otherObj) {
        // Deletes itself on collision with Wall.
        if (otherObj.gameObject.tag == "Border")
			Destroy (gameObject);

        // Reflects on collision with Mirrors
		if (otherObj.gameObject.tag == "Mirror")
        {
            if (isLive)
            {
                float m = otherObj.transform.rotation.eulerAngles.z; // Angle of the mirror
                float a = transform.rotation.eulerAngles.z;          // Angle of the bolt
                float theta = ((2 * m) - a) + 180;  // Thank you TJ For helping me work out math.
                
                // Rotates the bolt, and resets the life timer.
                transform.rotation = Quaternion.AngleAxis(theta, transform.forward);
                rb2d.velocity = transform.up * rb2d.velocity.magnitude;
                timeLive = Time.time + minLiving;
            } else
            {
                Destroy(gameObject);     
            }
        }

        if (otherObj.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
	}


}
