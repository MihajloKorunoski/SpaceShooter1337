using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed { get; set; }

    private Vector2 dir;
    public bool isFromPlayer { get; set; }
    
    public void Init(Vector2 myDir, float mySpeed, bool isFromPl)
    {
        dir = myDir;
        this.speed = mySpeed;
        isFromPlayer = isFromPl;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * dir * Time.deltaTime);

        if (transform.position.y >= GameMenager.topRightPosition.y)
        {
            Destroy(gameObject);
        }
    }
}