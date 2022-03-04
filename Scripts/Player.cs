using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletForce = 400;
    int life = 5;
    int score = 0;

    AudioSource _audioSource;
    public AudioClip shootSound;

    Rigidbody2D _rigidbody;

    public GameObject bulletPrefab;

    public TextMeshProUGUI lifeUI;
    public TextMeshProUGUI scoreUI;

    public GameObject explosion;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();

        //life.text = "1";
        lifeUI.text = "Life: " + life;
        scoreUI.text = "Score: " + score;
    }

   
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;

        _rigidbody.velocity = new Vector2(xSpeed, ySpeed);

        if(Input.GetButtonDown("Jump")){
            _audioSource.PlayOneShot(shootSound);
            GameObject newbullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); //quanternion means no change of rotation
            newbullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletForce));


        }

        if(life <1)
        {
            SceneManager.LoadScene("Lose");
        }

        if(score > 10)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            life--;
            lifeUI.text = "Life: " + life;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    public void AddScore(int addNum) //public then can reference in other scriptes!
    {
        score += addNum;
        scoreUI.text = "Score: " + score;
    }
}
