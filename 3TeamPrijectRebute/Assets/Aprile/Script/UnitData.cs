using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObject/UnitData")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public int cost;
    public float maxHp;
    public float attackPower;
    public float moveSpeed;
    public float attackRange;
    public float attackDelay;
}