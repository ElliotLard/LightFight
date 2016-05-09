using UnityEngine;
using System.Collections;

public class Pistol : Gun {

    override public void fire()
    {
        Instantiate(shotType, transform.position, transform.rotation);
    }
}
