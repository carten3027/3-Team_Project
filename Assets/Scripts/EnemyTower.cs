using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : MonoBehaviour
{
    public float enemy_tower_hp;                       // 타워 체력

    private void EnmTower_TakeDamage(float damage)
    {
        enemy_tower_hp -= damage;

        if (enemy_tower_hp <= 0f)
        {
            Debug.Log("적군 타워 사망");
            Destroy(gameObject);
        }
    }

    private void what_tower_ability()
    {
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            tower_ability_1();
        }
        if (SceneManager.GetActiveScene().name == "stage2")
        {
            tower_ability_1();
        }
        if (SceneManager.GetActiveScene().name == "stage3")
        {
            tower_ability_2();
        }
    }

    private void tower_ability_1()
    {

    }

    private void tower_ability_2()
    {

    }

    void Update()
    {
        
    }
}
