using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knife;

    private float max_X = 2.7f;
    private float min_X = -2.7f;

    public AudioSource _knife;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Spawning());
    }

    void Update()
    {
        if (knife.transform.position.y < -3.65)
            Destroy(gameObject);
       // SetBounds();
    }

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        GameObject k = Instantiate(knife);
        _knife.Play();
            k.transform.position = new Vector2 (Random.Range(min_X, max_X), transform.position.y);

        StartCoroutine(Spawning());

    }

    //void SetBounds()
    //{
    //    Vector2 temp = transform.position;
    //    if (temp.x > max_X)
    //        temp.x = max_X;
    //    else if (temp.x < min_X)
    //        temp.x = min_X;

    //    transform.position = temp;
    //}


}
