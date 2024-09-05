using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Troop Status")]
    [SerializeField] private int life;
    [SerializeField] private int damage;
    [SerializeField] private int velocity;

    private Animator troopAnimator;


    [Header("Prefab Variables")]
    private Rigidbody2D rb;
    private Transform trasform;

    [SerializeField] private bool canMove;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Vector3 attackSize;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float timeToAttack;
    private float elapsedTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trasform = GetComponent<Transform>();
    }

    private void Update()
    {
        TroopMovement();
        AttackCheck();

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void TroopMovement()
    {
        if (canMove)
        {
            Vector2 directionToMove = new Vector2(-1 * velocity, rb.velocity.y);
            rb.velocity = directionToMove;
        }
        else if (!canMove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void AttackCheck()
    {
        Collider2D enemyInRange = Physics2D.OverlapBox(attackPoint.position, attackSize, 0, playerLayer);

        if (enemyInRange)
        {
            canMove = false;
            Attack(enemyInRange);
        }
        else if (!enemyInRange)
        {
            canMove = true;
        }
    }

    private void Attack(Collider2D attackArea)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeToAttack && attackArea.TryGetComponent(out TroopBehavior troopBehavior))
        {
           troopBehavior.TakeDamage(damage);
           elapsedTime = 0;
        }
    }

    public void TakeDamage(int damageTaken)
    {
        life -= damageTaken;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackPoint.position, attackSize);
    }

}
