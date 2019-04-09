using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private float accelerationTime = 2f;

    [SerializeField]
    private float maxSpeed = 5f;

    private Vector2 movement;
    private float timeLeft;
    private Rigidbody2D rb;

    [SerializeField]
    private int powerupID;

    public AudioClip powerupPickupSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.ShieldPowerupOn();
                }
                else if (powerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }
                else if (powerupID == 2)
                {
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 3)
                {
                    player.DoubleShotPowerupOn();
                }
            }

            AudioSource.PlayClipAtPoint(powerupPickupSound, Camera.main.transform.position);

            Destroy(this.gameObject);
        }
    }
}
