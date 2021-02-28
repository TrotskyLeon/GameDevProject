using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //camera folow 1
    public Transform playerToFollow;

    //camera zoom 2
    Camera cam;

    private float targetZoom;

    private float zoomFactor = 3f;
    private float zoomLerpSpeed = 10;

    //camera state 3
    private bool fixedState = false;

    //player rotate
    public GameObject player;

    //shooting
    public GameObject bulletPrefab;
    public Transform gun;
    public float bulletSpeed = 750;

    void Start()
    {
        //camera zoom 2
        cam = this.GetComponent<Camera>();
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        if (fixedState == false)
        {
            //camera follow 1
            this.transform.position = new Vector3(playerToFollow.position.x, playerToFollow.position.y, -10);

            //camera zoom 2
            float scrollData;
            scrollData = Input.GetAxis("Mouse ScrollWheel");

            targetZoom -= scrollData * zoomFactor;

            targetZoom = Mathf.Clamp(targetZoom, 4.5f, 8f);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
        }

        // camera state 3
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleState();
        }

        // player rotate
        Vector2 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - (Vector2)player.transform.position).normalized;
        player.transform.up = direction;

        //shoot
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(bulletPrefab, gun.position, gun.rotation);
            obj.name = "bullet";
            obj.GetComponent<Rigidbody2D>().AddForce(gun.up * bulletSpeed);
        }
    }

    void toggleState()
    {
        fixedState = !fixedState;

        if (fixedState == true)
        {
            this.transform.position = new Vector3(0, 0, -10);
            cam.orthographicSize = 8f;
        }
    }
}
