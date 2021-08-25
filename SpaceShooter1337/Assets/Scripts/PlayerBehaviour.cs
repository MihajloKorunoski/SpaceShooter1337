using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // configuration parameters
    
    [SerializeField] private Transform spawnSpot;
    [SerializeField] private Laser laserPrefab;
    [SerializeField]float speed = 10f;
    private float radius { get; set; }
    private float laserSpeed { get; set; }
    private float invokeRepeatingTime { get; set; }
    private float repeatRate { get; set; }

    public delegate void CoinGaining();
    public event CoinGaining GainCoin;
    
    public delegate void PlayerDying();
    public event PlayerDying PlayerDied;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            if (GainCoin != null)
                GainCoin();
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("Enemy"))
        {
            if(PlayerDied != null)
                PlayerDied();
        }

        if (other.transform.CompareTag("Laser"))
        {
            Laser laser = other.GetComponent<Laser>();
            if (!laser.isFromPlayer)
            {
                if (PlayerDied != null)
                    PlayerDied();
                Destroy(other.gameObject);
            }
                
        }
    }

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