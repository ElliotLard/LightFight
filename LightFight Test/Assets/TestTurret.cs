using UnityEngine;
using System.Collections;

public class TestTurret : MonoBehaviour {
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
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, firePoint.position, firePoint.rotation);
        }
    }
}
