using UnityEngine;
using System.Collections;
using System;

public class Shotgun : Gun {
    public float spread; // The total angular spread of the shots.
    public int n; // Number of bullets
    private float inSpread; // Individual spread, the angle between each shot.
    void Start()
    {
        inSpread = spread / n - 1;
    }

    override public void fire()
    {
        float theta = transform.rotation.eulerAngles.z - (spread/2);
        for (int i = 0; i < n; i ++)
        {
            Instantiate(shotType, transform.position, Quaternion.AngleAxis(theta, transform.forward));
            theta += inSpread;
        }
    }
}
