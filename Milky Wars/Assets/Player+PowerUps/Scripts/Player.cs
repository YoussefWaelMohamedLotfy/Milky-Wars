using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool canDoubleShot = false;
    public bool canSpeedBoost = false;
    public bool isShieldActive = false;

    private Rigidbody2D rb;
    public float speed = 3.0f;
    public float maxVelocity = 5.0f;
    public int health = 3;
    private AudioSource laserShot;
    //public float rotationSpeed = 6.0f; // For Keyboard control only

    [SerializeField]
    private GameObject playerLaserPrefab;

    [SerializeField]
    private GameObject tripleShotPrefab;

    [SerializeField]
    private GameObject doubleShotPrefab;

    [SerializeField]
    private GameObject shieldPrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        laserShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        float playerHorizontalMovement = Input.GetAxis("Horizontal");
        float playerVerticalMovement = Input.GetAxis("Vertical");



        if (canSpeedBoost)
        {
            transform.Translate(Vector2.right * playerHorizontalMovement * speed * 2 * Time.deltaTime);
            transform.Translate(Vector2.up * playerVerticalMovement * speed * 2 * Time.deltaTime);
            //ThrustForward(playerVerticalMovement * speed * 2);
        }
        else
        {
            transform.Translate(Vector2.right * playerHorizontalMovement * speed * Time.deltaTime);
            transform.Translate(Vector2.up * playerVerticalMovement * speed * Time.deltaTime);
            //ThrustForward(playerVerticalMovement * speed);
        }

        Rotate(/*transform, -playerHorizontalMovement * rotationSpeed*/);
    }

    /// <summary>
    /// Adds a force to the player
    /// </summary>
    /// <param name="amount"> Amount of force to be applied </param>
    void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }

    /// <summary>
    /// Rotates the player
    /// </summary>
    void Rotate(/*Transform t, float amount*/)
    {
        // Keyboard Rotation Control
        //t.Rotate(0, 0, amount);

        // Mouse Rotation Control
        Vector3 lookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

    void Shoot()
    {
        // Mouse Rotation Control
        if (Input.GetMouseButtonDown(0))
        {
            laserShot.Play();

            if (canDoubleShot & !canTripleShot)
            {
                Instantiate(doubleShotPrefab, this.gameObject.transform.GetChild(2).transform.position, this.gameObject.transform.GetChild(2).transform.rotation);
            }
            else if (canTripleShot & !canDoubleShot)
            {
                Instantiate(tripleShotPrefab, this.gameObject.transform.GetChild(2).transform.position, this.gameObject.transform.GetChild(2).transform.rotation);
            }
            else
            {
                Instantiate(playerLaserPrefab, this.gameObject.transform.GetChild(2).transform.position, this.gameObject.transform.GetChild(2).transform.rotation);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy Laser" || other.gameObject.tag == "Enemy")
        {
            if (isShieldActive == false)
            {
                Linker.Health-=10;
            }
            Linker.GotAttacked = true;
            Destroy(other.gameObject);
        }

        if (Linker.Health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Triple Shot Powerup
    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    // Double Shot Powerup
    public void DoubleShotPowerupOn()
    {
        canDoubleShot = true;
        StartCoroutine(DoubleShotPowerDownRoutine());
    }

    public IEnumerator DoubleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canDoubleShot = false;
    }

    // Speed Boost Powerup
    public void SpeedBoostPowerupOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerupDownRoutine());
    }

    public IEnumerator SpeedBoostPowerupDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedBoost = false;
    }

    // Shield Powerup
    public void ShieldPowerupOn()
    {
        isShieldActive = true;
        shieldPrefab.SetActive(true);
        StartCoroutine(ShieldPowerupDownRoutine());
    }

    public IEnumerator ShieldPowerupDownRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        isShieldActive = false;
        shieldPrefab.SetActive(false);
    }
}
