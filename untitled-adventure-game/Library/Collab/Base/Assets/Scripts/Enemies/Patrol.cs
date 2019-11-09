using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;
    //variables to control the fire rate
    private float _canFire = -1.0f;
    private float _fireRate = 0.5f;

    [SerializeField] private GameObject _particlePrefab;

    private bool movingLeft = true;

    //public Transform groundDetection;


    private void Update()
    {
        /*transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false) {

            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }

        }*/
        if (Time.time > _canFire)
        {
            fireParticle();
        }
    }

    void fireParticle()
    {
        //used to control the firing rate
        _canFire = Time.time + _fireRate;

        Instantiate(_particlePrefab, transform.position + new Vector3(-0.4f, -0.25f, 0), Quaternion.identity);
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

}
