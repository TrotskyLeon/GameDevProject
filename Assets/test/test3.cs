using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{
    GameObject target = null;
    public float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Vector2)target.GetComponent<Transform>().position - (Vector2)transform.position;
        transform.up = direction;

        this.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
}
