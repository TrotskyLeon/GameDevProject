using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        playAudio("gunfire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playAudio("hit");
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<Collider2D>());
            StartCoroutine(DestroyAfterTime(2, gameObject));
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Wall"))
        {
            playAudio("thud");
            source.time = 0.2f;
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<Collider2D>());
            StartCoroutine(DestroyAfterTime(2, gameObject));
        }
    }

    public void playAudio (string audioName)
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = (AudioClip)Resources.Load("Audio/" + audioName);
        source.volume = 0.15f;
        source.Play();
    }

    IEnumerator DestroyAfterTime(float time, GameObject dead)
    {
        yield return new WaitForSeconds(time);
        Destroy(dead.gameObject);
    }
}
