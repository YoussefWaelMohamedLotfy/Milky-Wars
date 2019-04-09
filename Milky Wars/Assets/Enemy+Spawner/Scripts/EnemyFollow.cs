using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projetcile;

    private Transform target;
    private bool FacingRight;

    // Start is called before the first frame update
    void Start()
    {
        FacingRight = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        }
        if(timeBetweenShots<=0)
        {
            Vector2 NewPos = new Vector2(transform.position.x, transform.position.y +25);
            Instantiate(projetcile,NewPos,Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
         Flip();
    }
    void Flip()
    {
        if((transform.position.x > target.position.x && !FacingRight) || (target.position.x > transform.position.x && FacingRight))
        {
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    void Attack()
    {
       
    }
   
}
