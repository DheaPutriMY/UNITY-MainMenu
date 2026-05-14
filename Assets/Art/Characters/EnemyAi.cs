using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    public float detectRange = 5f;
    public float loseRange = 8f;

    public float stopDistance = 0.2f;

    private Rigidbody2D rb;

    private int patrolIndex = 0;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float distanceToPlayer =
            Vector2.Distance(transform.position, player.position);

        // Mulai ngejar
        if (distanceToPlayer <= detectRange)
        {
            isChasing = true;
        }

        // Berhenti ngejar, balik patrol
        if (distanceToPlayer >= loseRange)
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            player.position,
            chaseSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[patrolIndex];

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            targetPoint.position,
            patrolSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);

        float distance =
            Vector2.Distance(transform.position, targetPoint.position);

        // Kalau sudah sampai titik patrol
        if (distance <= stopDistance)
        {
            patrolIndex++;

            if (patrolIndex >= patrolPoints.Length)
            {
                patrolIndex = 0;
            }
        }
    }
}