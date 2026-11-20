using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Unit[] NownUnits = FindObjectsByType<Unit>();   // 나온 유닛 모두 감지

            if (SceneManager.GetActiveScene().name == "stage3")
            {
                foreach (Unit i in NownUnits)
                {
                    i.unitData.moveSpeed += 2f;
                    i.unitData.attackDelay *= 0.5f;
                }
            }
        }
    }

    public void FriTower_TakeDamage(float damage)
    {
        friend_tower_hp -= damage;
    }

    private IEnumerator Laser_Use()
    {
        // 레이저 한방에 지우기위해 리스트에 저장
        GameObject l1 = Instantiate(Laser, new Vector2(7.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l2 = Instantiate(Laser, new Vector2(6.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l3 = Instantiate(Laser, new Vector2(5.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l4 = Instantiate(Laser, new Vector2(4.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l5 = Instantiate(Laser, new Vector2(3.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l6 = Instantiate(Laser, new Vector2(2.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l7 = Instantiate(Laser, new Vector2(1.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l8 = Instantiate(Laser, new Vector2(0.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l9 = Instantiate(Laser, new Vector2(-0.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l10 = Instantiate(Laser, new Vector2(-1.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l11 = Instantiate(Laser, new Vector2(-2.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l12 = Instantiate(Laser, new Vector2(-3.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l13 = Instantiate(Laser, new Vector2(-4.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l14 = Instantiate(Laser, new Vector2(-5.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l15 = Instantiate(Laser, new Vector2(-6.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject l16 = Instantiate(Laser, new Vector2(-7.5f, -4f), Quaternion.identity);
        yield return new WaitForSeconds(1f);

        Destroy(l1); Destroy(l2); Destroy(l3); Destroy(l4); Destroy(l5); Destroy(l6); Destroy(l7); Destroy(l8);
        Destroy(l9); Destroy(l10); Destroy(l11); Destroy(l12); Destroy(l13); Destroy(l14); Destroy(l15); Destroy(l16);
    }

    private void Heal_Our()
    {
        Unit[] NownUnits = FindObjectsByType<Unit>();   // 나온 유닛 모두 감지
        foreach (Unit i in NownUnits)
        {
            i.currentHp = Mathf.Clamp(i.currentHp + 5f, 0f, i.unitData.maxHp);
        }
    }

    private void Use_Barrier()
    {
        GameObject barrierInstance = Instantiate(Barrier, new Vector2(9f, -5f), Quaternion.identity);
        Destroy(barrierInstance, 3f);
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
    void towerShoot()
    {
        if (towerManager.user_choosen_tower == 1)
        {
            if (Input.GetKeyDown(KeyCode.U))        // 일단 키보드로 사용
            {
                StartCoroutine(Laser_Use());
            }
            Unit_spwaner();
        }
        if (towerManager.user_choosen_tower == 2)
        {
            if (Input.GetKeyDown(KeyCode.U))        // 일단 키보드로 사용
            {
                Heal_Our();
                Debug.Log("아군 힐");
                Use_Barrier();
                Debug.Log("베리어 가동");
            }
            Unit_spwaner();
        }
        if (towerManager.user_choosen_tower == 3)
        {
            Unit_spwaner();
        }
    }

    void Update()
    {
        if (friend_tower_hp <= 0f)
        {
            Debug.Log("아군 타워 사망");
            Destroy(gameObject);
        }
        towerShoot();
    }
}