using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerManager : MonoBehaviour
{

    public int user_choosen_tower;

    public GameObject Blaster_Tower;
    public GameObject Aegis_Tower_Friend;
    public GameObject Overclock_Tower_Friend;

    public GameObject Aegis_Tower_Enemy;
    public GameObject Overclock_Tower_Enemy;

    void spwan_user_tower() 
    {
        switch (user_choosen_tower) 
        {
            case 1:
                Instantiate(Blaster_Tower, new Vector2((float)8.38, (float)-4.5), Quaternion.identity);
                break;
            case 2:
                Instantiate(Aegis_Tower_Friend, new Vector2((float)8.38, (float)-4.5), Quaternion.identity);
                break;
            case 3:
                Instantiate(Overclock_Tower_Friend, new Vector2((float)8.38, (float)-4.5), Quaternion.identity);
                break;
        }
    }

    void spwan_enemy_tower()
    {
        if (SceneManager.GetActiveScene().name == "stage1" || SceneManager.GetActiveScene().name == "stage2")
        {
            Instantiate(Aegis_Tower_Enemy, new Vector2((float)-8.38, (float)-4.5), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "stage3")
        {
            Instantiate(Overclock_Tower_Enemy, new Vector2((float)-8.38, (float)-4.5), Quaternion.identity);
        }
    }

    void Start()
    {
        spwan_user_tower();
        spwan_enemy_tower();
    }
}
