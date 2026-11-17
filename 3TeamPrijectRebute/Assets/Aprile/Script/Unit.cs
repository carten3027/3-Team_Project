using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unitData;
    public LayerMask enemyLayer;

    private float currentHp;
    private float attackTimer;

    void Start()
    {
        currentHp = unitData.maxHp;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, unitData.attackRange, enemyLayer);

        if (hit.collider != null)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= unitData.attackDelay)
            {
                Attack(hit.collider.gameObject);
                attackTimer = 0f;
            }
        }
        else
        {
            transform.Translate(Vector2.left * unitData.moveSpeed * Time.deltaTime);
            attackTimer = 0f;
        }
    }

    void Attack(GameObject target)
    {
        Debug.Log(unitData.unitName + " АјАн: " + unitData.attackPower);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        if (unitData != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.left * unitData.attackRange);
        }
    }
}