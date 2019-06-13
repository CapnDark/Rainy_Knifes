using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public Text scoreText;
    private float timer;

    private Animator anim;
    private SpriteRenderer sr;

    private float max_X = 2.7f;
    private float min_X = -2.7f;

    public AudioSource Die;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        timer = 0f;
        StartCoroutine(TimeCount());
    }

    // Update is called once per frame
    void Update()
    {
        SetBounds();
        Move();
        scoreText.text = timer.ToString("0");
    }

    void SetBounds()
    {
        Vector2 temp = transform.position;
        if (temp.x > max_X)
            temp.x = max_X;
        else if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp;
    }

    void Move()
    {
        Vector3 temp = transform.position;
        float k = Input.GetAxisRaw("Horizontal");
        if (k > 0)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("Walk", true);
        }

        else if (k < 0)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("Walk", true);

        }

        else
        {
            anim.SetBool("Walk", false);
        }

        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            GameObject.Destroy(collision.gameObject);
            Time.timeScale = 0f;
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(1f);
        timer++;

        StartCoroutine(TimeCount());
    }

    IEnumerator RestartGame()
    {
        Die.Play();
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("Menu");
    }
}
