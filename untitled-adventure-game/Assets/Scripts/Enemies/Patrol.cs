using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private bool movingRight = true;

    GameObject enemy;
    Rigidbody2D rb;

    public Transform groundDetection;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        rb = enemy.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("Rb is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
        //TurnCharModel();
        //moves the enemy right
        /*transform.Translate(Vector3.right * _speed * Time.deltaTime);
        //creates a ray starts that shoots downward at the position of ground detection for a distance of 2
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, _distance);
        if (groundInfo.collider == null)
        {
            Debug.Log("Raycast is null");
        }
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                Debug.Log("Moving Right");
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                Debug.Log("Moving Left");
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }*/
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if other is player
        //damage player
        if (other.tag == "Player")
        {
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if (player != null)
            {
               player.Damage();
            }
        }
    }

    void TurnCharModel()
    {
        if (rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
