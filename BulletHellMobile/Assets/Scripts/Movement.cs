using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    //fighterWhi (-14.6,21.5,-0.6,14.6
    public float xMin, xMax, zMin, zMax;
}


public class Movement : MonoBehaviour
{
    //lock down movement within screen
    public Boundary boundary;
    bool attacking = false;
    float Horz,Upz, tilt;
    public float speed = 25.0f;

    //BulletStuff
    public GameObject missile;
    public Transform bulletSpawn;
    public float fireRate;
    public float nextShot;

    //Health Bar 
    float maxHealth, damage, currentHealth;
    public GUIText health;

    // Use this for initialization
    void Start()
    {
        


        // HPLoc = new Vector2(HP.transform.position.x, HP.transform.position.y);
        //LPLoc = new Vector2(LP.transform.position.x, LP.transform.position.y);
        // anim = GetComponent<Animator>();
        damage = 10.0f;
        maxHealth = 100;
        tilt = 2.3f;
       // currentHealth = maxHealth;
       // health.text = currentHealth.ToString();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
   
       
        Horz = Input.GetAxis("Horizontal");
        Upz = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(Horz, 0.0f, Upz);
        GetComponent<Rigidbody>().velocity = movement * speed;


        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
       
        
        
        ////punch Check HIGH
        //if (Input.GetButton("Y1"))
        //{
        //    attacking = true;
        //    anim.SetBool("HighPunch", true);
        //    move = 0;
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        //}
        //else if (!Input.GetButton("Y1"))
        //{
        //    anim.SetBool("HighPunch", false);
        //    attacking = false;
        //}
        
    }
    void Update()
    {

        //Shooting check
        if (Input.GetButtonDown("Fire1") )//&& Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            Instantiate(missile, bulletSpawn.position, bulletSpawn.rotation);
        }

        ///health.text = currentHealth.ToString();
        //		Vector3 direction = target.position -transform.position;
        //		float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        //		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //		Vector2 lookpt = new Vector2(target.transform.position.x, transform.position.y);
        //		transform.LookAt(new Vector3(lookpt.x,lookpt.y,0));

       // HPLoc = new Vector2(HP.transform.position.x, HP.transform.position.y);


   


    }
    //void TakeDamage(float damage)
    //{
    //    currentHealth -= damage;
    //    if (currentHealth <= 0)
    //    {

    //        Application.LoadLevel("End 1");
    //    }
    //}
    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 scale = transform.localScale;
    //    scale.x *= -1;
    //    transform.localScale = scale;
    //}
    //public void hit()
    //{
    //    Collider2D hit = Physics2D.OverlapCircle(HPLoc, 0.5f, P2);
    //    if (hit)
    //    {
    //        if (hit.transform.tag == "P2")
    //        {
    //            Debug.Log("hit");
    //            p2Anim.SetBool("GotHit", true);
    //            if (facingRight)
    //            {
    //                hit.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(150, 0));
    //                hit.SendMessage("TakeDamage", damage);
    //            }
    //            else if (!facingRight)
    //            {
    //                hit.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-150, 0));
    //                hit.SendMessage("TakeDamage", damage);
    //            }
    //            hit = null;
    //        }

    //    }
    //    else if (!hit)
    //    {
    //        Debug.Log("Miss");
    //        p2Anim.SetBool("GotHit", false);
    //    }


    //}

    //public void setFalse()
    //{
    //    p2Anim.SetBool("GotHit", false);

    //}
}
