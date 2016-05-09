using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour {

    public float fireRate;
    private float nextFire;
    public GameObject shotType;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    public abstract void fire();
}
