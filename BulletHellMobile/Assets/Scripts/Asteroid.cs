using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    public float rotation;
    float speed = 10.0f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * speed;
    }
}
