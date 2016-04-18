using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MMButton : MonoBehaviour {

    public int level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(level);
        }
	}
}
