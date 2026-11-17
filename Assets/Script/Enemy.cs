using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyAtk = 0f;
    public float EnemyHp = 0f;
    public float EnemySpeed = 0f;
    public float Cool = 0f;
    public bool Touch = false;
    public bool IsAttacking = false;
    public GameObject CollidingOBJ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Team") || collision.gameObject.CompareTag("OurTower"))
        {
            Touch = true;
            CollidingOBJ = collision.gameObject;
            //Comp = CollidingOBJ.GetComponent<아군 캐릭터 컴포넌트>();  아군 캐릭터 컴포넌트 가져오는 코드
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Team") || collision.gameObject.CompareTag("OurTower"))
        {
            Touch = false;
        }
    }
    private void Update()
    {
        if (Touch == false)
        {
            transform.position += Vector3.right * EnemySpeed * Time.deltaTime;
        }
        else
        {
            if (IsAttacking == false)
            {
                IsAttacking = true;
                StartCoroutine("EnemyAttack");
            }
        }
        if (EnemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator EnemyAttack()
    {
        Debug.Log(this.gameObject + "이/가 공격시작");
        yield return new WaitForSeconds(Cool);
        if (CollidingOBJ != null)
        {
            //Comp.Hp -= EnemyAtk;  가져온 아군 컴포넌트에서 HP를 EnemyAtk많큼 줄이기
            IsAttacking = false;
            Debug.Log(this.gameObject.name + "이/가 " + EnemyAtk + "의 데미지로 공격함");
        }
    }
}                                                   