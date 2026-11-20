using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : MonoBehaviour
{
    public FriendTower friendTower;
    public Enemy enemy;

    private Transform Spwan_Point;

    public float enemy_tower_hp;                       // 타워 체력
    public GameObject Barrier_Enm;

    public GameObject Enm_MonoSlime;
    public GameObject Enm_ShadowHound;
    public GameObject Enm_IronGolem;
    public GameObject Enm_DarkSniper;
    public GameObject Enm_GearBomber;
    public GameObject Enm_Boss_ArkZero;

    bool isBossSpawn = false;                         // 보스 소환 감지, 보스 무한 소환 방지용

    int DarkSniper_Chance;

    void Awake()
    {
        Spwan_Point = transform.Find("Spwan_Point");
    }

    private void Start()
    {
        StartCoroutine(Enemy_Wave());
        StartCoroutine(Enemy_Tower_Abilty());
    }

    public void EnmTower_TakeDamage(float damage)
    {
        enemy_tower_hp -= damage;
    }

    private void Heal_Our()
    {
        Enemy[] NownEnemys = FindObjectsByType<Enemy>();   // 나온 유닛 모두 감지
        foreach (Enemy i in NownEnemys)
        {
            i.EnemyHp = i.EnemyHp + 5f;
        }
    }

    private void Use_Barrier()
    {
        GameObject barrierInstance = Instantiate(Barrier_Enm, new Vector2(-9f, -5f), Quaternion.identity);
        Destroy(barrierInstance, 3f);
    }

    private void Spawn(GameObject mobPrefab)
    {
        if (mobPrefab == null) return;

        Enemy SpawnedEnemy = Instantiate(mobPrefab, Spwan_Point.position, Quaternion.identity).GetComponent<Enemy>();

        if (SceneManager.GetActiveScene().name == "stage3")
        {
            SpawnedEnemy.EnemySpeed += 2f;
            SpawnedEnemy.Cool *= 0.5f;
        }
    }

    private void Mob_Spawn(string spwan_mob)
    {
        if (spwan_mob == "MS")
        {
            Spawn(Enm_MonoSlime);
        }
        if (spwan_mob == "SH")
        {
            Spawn(Enm_ShadowHound);
        }
        if (spwan_mob == "IG")
        {
            Spawn(Enm_IronGolem);
        }
        if (spwan_mob == "DS")
        {
            Spawn(Enm_DarkSniper);
        }
        if (spwan_mob == "GB")
        {
            Spawn(Enm_GearBomber);
        }
        if (spwan_mob == "Boss")
        {
            Spawn(Enm_Boss_ArkZero);
        }
    }

    private IEnumerator Enemy_Wave()
    {
        while (enemy_tower_hp > 0)
        {
            if (SceneManager.GetActiveScene().name == "stage1")
            {
                Mob_Spawn("MS");
                yield return new WaitForSeconds(0.6f);
                Mob_Spawn("SH");
                yield return new WaitForSeconds(0.6f);
            }

            if (SceneManager.GetActiveScene().name == "stage2")
            {
                DarkSniper_Chance = Random.Range(0, 26);
                Mob_Spawn("MS");
                yield return new WaitForSeconds(0.6f);
                Mob_Spawn("SH");
                yield return new WaitForSeconds(0.3f);
                Mob_Spawn("GB");
                yield return new WaitForSeconds(0.5f);
                Mob_Spawn("GB");
                yield return new WaitForSeconds(0.6f);
                if (DarkSniper_Chance == 0)
                {
                    Mob_Spawn("DS");
                    yield return new WaitForSeconds(0.8f);
                }
            }
            if (SceneManager.GetActiveScene().name == "stage3")
            {
                DarkSniper_Chance = Random.Range(0, 26);
                Mob_Spawn("MS");
                yield return new WaitForSeconds(0.6f);
                Mob_Spawn("SH");
                yield return new WaitForSeconds(0.3f);
                Mob_Spawn("GB");
                yield return new WaitForSeconds(0.5f);
                Mob_Spawn("GB");
                yield return new WaitForSeconds(0.6f);
                if (DarkSniper_Chance == 0)
                {
                    Mob_Spawn("DS");
                    yield return new WaitForSeconds(0.8f);
                }
                Mob_Spawn("IG");
                yield return new WaitForSeconds(0.6f);
            }
        }
    }

    private IEnumerator Enemy_Tower_Abilty()
    {
        while (enemy_tower_hp > 0)
        {
            if (SceneManager.GetActiveScene().name == "stage1")
            {
                yield return new WaitForSeconds(0.5f);
                int RAND_VUL = Random.Range(1, 26);
                if (RAND_VUL == 1)
                {
                    Heal_Our();
                    Debug.Log("적군 힐");
                    Use_Barrier();
                    Debug.Log("적군 베리어 가동");
                }
            }
            else if (SceneManager.GetActiveScene().name == "stage2")
            {
                yield return new WaitForSeconds(0.3f);
                int RAND_VUL = Random.Range(1, 26);
                if (RAND_VUL == 1)
                {
                    Heal_Our();
                    Debug.Log("적군 힐");
                    Use_Barrier();
                    Debug.Log("적군 베리어 가동");
                }
            }
            else if (SceneManager.GetActiveScene().name == "stage3")
            {
                if (enemy_tower_hp <= 1120 && isBossSpawn == false)
                {
                    Mob_Spawn("Boss");
                    isBossSpawn = true;
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    void Update()
    {
        if (enemy_tower_hp <= 0f)
        {
            Debug.Log("적군 타워 사망");
            Destroy(gameObject);
            return;
        }
    }
}