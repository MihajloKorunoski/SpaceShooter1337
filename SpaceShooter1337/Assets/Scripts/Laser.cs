using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed { get; set; }

    public void Init(float mySpeed)
    {
        this.speed = mySpeed;
        transform.localPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector2.up * Time.deltaTime);
    }
}