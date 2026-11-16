using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : MonoBehaviour
{
    private Transform Spwan_Point;

    public float enemy_tower_hp;                       // 타워 체력
    public GameObject Barrier_Enm;

    public GameObject Enm_MonoSlime;
    public GameObject Enm_ShadowHound;
    public GameObject Enm_IronGolem;
    public GameObject Enm_DarkSniper;
    public GameObject Enm_GearBomber;
    public GameObject Enm_Boss_ArkZero;

    void Awake()
    {
        Spwan_Point = transform.Find("Spwan_Point");
    }

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
            tower_ability_2();
        }
        if (SceneManager.GetActiveScene().name == "stage3")
        {
            tower_ability_3();
        }
    }

    private void tower_ability_1()
    {
        while (true)
        {
            if (enemy_tower_hp <= 0)
            {
                break;
            }
            int RAND_VUL = Random.Range(1, 26);
            if (RAND_VUL == 1)
            {
                Heal_Our();
                Debug.Log("아군 힐");
                Use_Barrier();
                Debug.Log("베리어 가동");
                FriendTower.Wait_time(1f);
            }
            Spawn("MS");
            FriendTower.Wait_time(0.7f);
            Spawn("MS");
            FriendTower.Wait_time(0.7f);
        }
    }

    private void tower_ability_2()
    {
        while (true)
        {
            int RAND_VUL = Random.Range(1, 26);
            if (RAND_VUL == 1)
            {
                Heal_Our();
                Debug.Log("아군 힐");
                Use_Barrier();
                Debug.Log("베리어 가동");
                FriendTower.Wait_time(1f);
            }

        }
    }

    private void tower_ability_3()
    {
        EnemyMove.EnemySpeed += 2;
        while (true)
        {
            if (enemy_tower_hp <= 1120)
            {
                break;
            }
        }
        Spawn("Boss");
    }

    private void Heal_Our()
    {
        Enemy.EnemyHp += 5;
    }

    private void Use_Barrier()
    {
        Instantiate(Barrier_Enm, new Vector2((float)9, (float)-5), Quaternion.identity);
        StartCoroutine(FriendTower.Wait_time(3f));
        Destroy(Barrier_Enm);
    }

    private void Spawn(string spwan_mob)
    {
        if (spwan_mob == "MS")
        {
            Instantiate(Enm_MonoSlime, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_mob == "SH")
        {
            Instantiate(Enm_ShadowHound, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_mob == "IG")
        {
            Instantiate(Enm_IronGolem, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_mob == "DS")
        {
            Instantiate(Enm_DarkSniper, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_mob == "GB")
        {
            Instantiate(Enm_GearBomber, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_mob == "Boss")
        {
            Instantiate(Enm_Boss_ArkZero, Spwan_Point.position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
