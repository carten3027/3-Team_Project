using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float EnemySpeed = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * EnemySpeed * Time.deltaTime;
    }
}
