using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public float speed;
    public float minLiving;
    private bool isLive;
    private float timeLive;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = transform.up * speed;
        timeLive = Time.time + minLiving;
    }

    void Update()
    {
        if (Time.time > timeLive) isLive = true; // "Live" basically means allowed to reflect.
        if (rb2d.velocity.magnitude < .3) Destroy(gameObject); // Temporary line for Testing Shotgun Shells
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
                float m = otherObj.transform.rotation.eulerAngles.z;
                float a = transform.rotation.eulerAngles.z;
                float theta = ((2 * m) - a) + 180;  // Thank you TJ For helping me work out math.
                Instantiate(gameObject, transform.position, Quaternion.AngleAxis(theta, transform.forward));
                Destroy(gameObject);
            }
        }

        // For now, bolts destroy each other.
        if (otherObj.gameObject.tag == "Bolt")
        {
            if (isLive)
            {
                Destroy(otherObj.gameObject);
                Destroy(gameObject);
            }
        }

        if (otherObj.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
	}


}
