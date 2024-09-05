using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TroopBehavior : MonoBehaviour
{
    [Header("Troop Status")]
    [SerializeField] private int life;
    [SerializeField] private int damage;
    [SerializeField] private int velocity;

    [Header("Troop Visuals")]
    private SpriteRenderer troopSprite;
    private AnimatorController animController;

    private Troop troopToSpawn;

    [Header("Prefab Variables")]
    private Rigidbody2D rb;
    private Transform trasform;
    private Animator animator;

    [SerializeField] private bool canMove;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Vector3 attackSize;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float timeToAttack;
    private float elapsedTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trasform = GetComponent<Transform>();
        troopSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        InsertTroopInformation();
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
            Vector2 directionToMove = new Vector2(1 * velocity, rb.velocity.y);
            rb.velocity = directionToMove;
        }
        else if (!canMove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void AttackCheck()
    {
        Collider2D enemyInRange = Physics2D.OverlapBox(attackPoint.position, attackSize, 0, enemyLayer);

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
        if (elapsedTime >= timeToAttack && attackArea.TryGetComponent(out EnemyBehavior enemyBehavior))
        {
            enemyBehavior.TakeDamage(damage);
            elapsedTime = 0;
        }
    }

    private void InsertTroopInformation()
    {
        troopToSpawn = TroopManager.instance.GetTroopInformation();
        life = troopToSpawn.life;
        damage = troopToSpawn.damage;
        velocity = troopToSpawn.velocity;
        troopSprite.sprite = troopToSpawn.troopSprite;
        animController = troopToSpawn.animController;
        animator.runtimeAnimatorController = animController;

    }

    public void TakeDamage(int damageTaken)
    {
        life -= damageTaken;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, attackSize);
    }

}
