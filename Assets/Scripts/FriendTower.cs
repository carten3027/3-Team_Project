using UnityEngine;

public class FriendTower : MonoBehaviour
{
    public float friend_tower_hp;                      // 타워 체력

    private void FriTower_TakeDamage(float damage)
    {
        friend_tower_hp -= damage;

        if (friend_tower_hp <= 0f)
        {
            Debug.Log("아군 타워 사망");
            Destroy(gameObject);
        }
    }

    private void what_tower_ability()
    {
        switch (TowerManager.user_choosen_tower)
        {
            case 1:
                tower_ability_1();
                break;
            case 2:
                tower_ability_2();
                break;
            case 3: 
                tower_ability_3(); 
                break;
        }
    }

    private void tower_ability_1()
    {

    }

    private void tower_ability_2()
    {

    }

    private void tower_ability_3()
    {

    }

    void Update()
    {
        
    }
}
