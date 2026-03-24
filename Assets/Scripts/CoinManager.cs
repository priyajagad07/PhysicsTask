using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int coins;
    public TMP_Text coinsText;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        coins += value;
        coinsText.text = "Coins: " + coins;
    }
}
