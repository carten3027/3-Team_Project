using System.Collections;
using UnityEngine;

public class FriendTower : MonoBehaviour
{
    public UnitData unitData;
    public Unit unit;
    public TowerManager towerManager;

    private Transform Spwan_Point;

    public float friend_tower_hp;                      // 타워 체력
    public GameObject Barrier;
    public GameObject Laser;

    public GameObject Unit_LittleGuardian;
    public GameObject Unit_ShieldBearer;
    public GameObject Unit_PrismArcher;
    public GameObject Unit_NeonLancer;
    public GameObject Unit_ChromaKnight;

    void Awake()
    {
        Spwan_Point = transform.Find("Spwan_Point");
    }

    private void Start()
    {
        if (towerManager.user_choosen_tower == 3)
        {
            unitData.moveSpeed += 2f;
            unitData.attackDelay = unitData.attackDelay / 2;
        }
    }

    private void FriTower_TakeDamage(float damage)
    {
        friend_tower_hp -= damage;
    }

    private void Use_Laser()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 Spawn_Laser_Pos = new Vector2(i * 1.5f, 0f);
            GameObject New_Laser_Pos = Instantiate(Laser, Spawn_Laser_Pos, Quaternion.identity);
        }
    }

    private void Heal_Our()
    {
        unit.currentHp += 5;
    }

    private void Use_Barrier()
    {
        Instantiate(Barrier, new Vector2((float)9, (float)-5), Quaternion.identity);
        StartCoroutine(Wait_time(3f));
        Destroy(Barrier);
    }

    public IEnumerator Wait_time(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void Spawn(string spwan_unit)
    {
        if (spwan_unit == "LG")
        {
            Instantiate(Unit_LittleGuardian, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_unit == "SB")
        {
            Instantiate(Unit_ShieldBearer, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_unit == "PA")
        {
            Instantiate(Unit_PrismArcher, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_unit == "NL")
        {
            Instantiate(Unit_NeonLancer, Spwan_Point.position, Quaternion.identity);
        }
        if (spwan_unit == "CK")
        {
            Instantiate(Unit_ChromaKnight, Spwan_Point.position, Quaternion.identity);
        }
    }

    private void Unit_spwaner()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spawn("LG");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Spawn("SB");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Spawn("PA");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Spawn("NL");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Spawn("CK");
        }
    }

    void Update()
    {
        if (towerManager.user_choosen_tower == 1)
        {
            if (friend_tower_hp <= 0f)
            {
                Debug.Log("아군 타워 사망");
                Destroy(gameObject);
            }
            if (Input.GetKeyDown(KeyCode.U))        // 일단 키보드로 사용
            {
                Use_Laser();
            }
            Unit_spwaner();
        }
        else if (towerManager.user_choosen_tower == 2)
        {
            if (friend_tower_hp <= 0f)
            {
                Debug.Log("아군 타워 사망");
                Destroy(gameObject);
            }
            if (Input.GetKeyDown(KeyCode.U))        // 일단 키보드로 사용
            {
                Heal_Our();
                Debug.Log("아군 힐");
                Use_Barrier();
                Debug.Log("베리어 가동");
            }
            Unit_spwaner();
        }
        else if (towerManager.user_choosen_tower == 3)
        {
            if (friend_tower_hp <= 0f)
            {
                Debug.Log("아군 타워 사망");
                Destroy(gameObject);
            }
            Unit_spwaner();
        }
    }
}
