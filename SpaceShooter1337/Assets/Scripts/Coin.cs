using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        float x = Random.Range(-50f, 100f);
        float y = Random.Range(50f, 100f);
        Vector2 force = new Vector2(x, y);

        body.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + transform.localScale.y < GameMenager.bottomLeftPosition.y)
            Destroy(gameObject);
    }
    
}