using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform spawnSpot;
    [SerializeField] private Laser laserPrefab;
    private float radius { get; set; }
    private float laserSpeed { get; set; }
    private float invokeRepeatingTime { get; set; }
    private float repeatRate { get; set; }

    void ShootLaser()
    {
        Laser laser = Instantiate(laserPrefab);
        laser.transform.position = spawnSpot.position;
        laserSpeed = 10f;
        laser.Init(Vector2.up, laserSpeed, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        radius = transform.localScale.x * 2f;
        invokeRepeatingTime = 0.5f;
        repeatRate = 0.15f;
        InvokeRepeating("ShootLaser", invokeRepeatingTime, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5f;
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (transform.position.x + radius >= GameMenager.topRightPosition.x && moveHorizontal > 0)
        {
            moveHorizontal = 0;
        }

        if (transform.position.x - radius <= GameMenager.bottomLeftPosition.x && moveHorizontal < 0)
        {
            moveHorizontal = 0;
        }

        transform.Translate(Vector2.right * moveHorizontal);

    }
}