using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gun;
    Rigidbody2D body;

    public float bulletSpeed = 750;
    float moveSpeed = 5;
    float horizontal;
    float vertical;
    float diagonalSpeed = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

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
            Destroy(gameObject);
        }
    }
}
