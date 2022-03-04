using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    public int scoreValue = 1;


    int speed = 2;

    public GameObject explosion;

    Player _player;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _player = FindObjectOfType<Player>(); //will find anything the tag associate, like scriptes!!

    }


    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(0, -speed); //x-axis no change but change y-axis
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);

            _player.AddScore(scoreValue);
        }
    }
}
