using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public float coins = 0f, rate = 10f;
    public int maxCoins = 1500, cost = 200;

    public TextMeshProUGUI coinText, costText;
    public Button upgradeBtn;

    void Update()
    {
        if (coins < maxCoins) coins += rate * Time.deltaTime;
        else coins = maxCoins;

        coinText.text = $"{(int)coins} / {maxCoins}";
        costText.text = cost.ToString();
        upgradeBtn.interactable = (coins >= cost);
    }

    public void UpgradeWalle()
    {
        if (coins < cost) return;

        coins -= cost;
        maxCoins += 500;
        rate += 5f;
        cost = (int)(cost * 1.5f);
    }
}