using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AudioSource bonkSound;

    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float stoppingDistance = 1f;
    private int currentPatrolIndex;
    private bool chasingPlayer;
    private bool movingForward = true;

    private Transform player;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        playerMovement = player.GetComponent<PlayerMovement>(); // Properly assign the reference
        currentPatrolIndex = 0;
        SetNextPatrolPoint();
    }

    private void Update()
    {
        if (chasingPlayer)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void SetNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        Vector2 direction = (targetPatrolPoint.position - transform.position).normalized;
        rb.velocity = direction * patrolSpeed;
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            if (movingForward)
            {
                currentPatrolIndex++;
                if (currentPatrolIndex >= patrolPoints.Length)
                {
                    currentPatrolIndex = patrolPoints.Length - 1;
                    movingForward = false;
                }
            }
            else
            {
                currentPatrolIndex--;
                if (currentPatrolIndex < 0)
                {
                    currentPatrolIndex = 0;
                    movingForward = true;
                }
            }

            SetNextPatrolPoint();
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            chasingPlayer = false;
            SetNextPatrolPoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chasingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chasingPlayer = false;
            SetNextPatrolPoint();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Corrected method name
    {
        if (collision.collider.CompareTag("Player"))
        {
            chasingPlayer = true;
            bonkSound.Play();
            playerMovement.DecreaseGatchaBall(); // Call the method to decrease gatcha ball count
        }
    }
}

