using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int minCoins = 2;
    public int maxCoins = 4;
    public float coinHeight = 1f;

    public void SpawnCoins(GameObject building)
    {
        Building b = building.GetComponent<Building>();

        int coinCount = Random.Range(minCoins, maxCoins);
        float centerX = building.transform.position.x;
        float width = b.width;
        float startX = centerX - (width / 2f);
        float spacing = width / (coinCount + 1);

        Renderer[] renderers = building.GetComponentsInChildren<Renderer>();
        Bounds bounds = renderers[0].bounds;

        foreach (Renderer r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }

        float topY = bounds.max.y;
        for (int i = 0; i <= coinCount; i++)
        {
            float x = startX + (spacing * i);
            float y = topY + 0.5f;

            Instantiate(coinPrefab, new Vector3(x + 3.5f, y, 0), Quaternion.identity);
        }
    }
}