using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform spawnSpot;
    [SerializeField] private Laser laserPrefab;
    private float Radius { get; set; }
    private float LaserSpeed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Radius = transform.localScale.x * 2f;
        
        Laser laser = Instantiate(laserPrefab);
        laser.transform.SetParent(spawnSpot);
        LaserSpeed = 5f;
        laser.Init(LaserSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (transform.position.x + Radius >= GameMenager.topRightPosition.x && moveHorizontal > 0)
        {
            moveHorizontal = 0;
        }

        if (transform.position.x - Radius <= GameMenager.bottomLeftPosition.x && moveHorizontal < 0)
        {
            moveHorizontal = 0;
        }

        transform.Translate(Vector2.right * moveHorizontal);
    }
}