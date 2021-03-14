using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public Transform gun;
    Rigidbody2D body;

    public Text healthText;
    public Text coinText;

    public float bulletSpeed = 750;
    float moveSpeed = 5;
    float horizontal;
    float vertical;
    float diagonalSpeed = 0.7f;

    int healthAmount = 3;
    public int coinAmount = 0;

    PauseScript pauseScript;

    AudioSource deathAudio;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        pauseScript = GameObject.Find("EventSystem").GetComponent<PauseScript>();

        deathAudio = GameObject.Find("DeathAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (!pauseScript.gamePaused)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - (Vector2)transform.position;
            transform.up = direction;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject obj = Instantiate(bulletPrefab, gun.position, gun.rotation);
                obj.name = "bullet";
                obj.GetComponent<Rigidbody2D>().AddForce(gun.up * bulletSpeed);
            }
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) 
        {
            horizontal *= diagonalSpeed;
            vertical *= diagonalSpeed;
        }

        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            healthAmount--;
            healthText.GetComponent<Text>().text = healthAmount.ToString();
            Destroy(collision.gameObject);

            if (healthAmount == 0)
            {
                deathAudio.Play();
                player.SetActive(false);
                gameOver();
            }
        }
    }

    private void gameOver()
    {
        pauseScript.pauseText.text = "GAME OVER";
        pauseScript.pauseText.fontStyle = FontStyle.Bold;
        pauseScript.gameOver = true;
        pauseScript.PauseGame();
    }
}
