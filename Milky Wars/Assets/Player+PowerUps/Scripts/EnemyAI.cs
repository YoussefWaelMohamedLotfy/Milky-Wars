using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform target;
    public GameObject enemyLaserPrefab;
    private float fireRate = 5.0f;
    private float canFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EnemyShoot();
    }

    void FollowPlayer()
    {
        //transform.LookAt(target);

        if (target != null)
        {
            float ang = Mathf.Atan2(target.position.y, target.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, ang + 90);

            // Force enemy to stop at a certain distance
            if (Vector2.Distance(transform.position, target.position) > 3.0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

    void EnemyShoot()
    {
        if (Time.time > canFire)
        {
            Instantiate(enemyLaserPrefab, this.gameObject.transform.GetChild(3).transform.position, this.gameObject.transform.GetChild(3).transform.rotation);
            canFire = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Linker.Score++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Linker.Score++;
            Destroy(this.gameObject);
        }
    }

}
