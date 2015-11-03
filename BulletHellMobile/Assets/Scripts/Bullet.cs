using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Boundary")
            Destroy(gameObject);
        else if (col.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
            
    }
    //void OnTriggerEnter(Collider col)
    //{
       
    //}
}
