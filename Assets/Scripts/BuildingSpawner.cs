using UnityEngine;

public class BuildingSpawner: MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public Transform player;
    public Transform lastBuilding;

    public float spawnDistance = 10f;
    public float minGap = 1.2f;
    public float maxGap = 2f;

    public float rightEdge;

    void Start()
    {
        Building building = lastBuilding.GetComponent<Building>();
        rightEdge = lastBuilding.position.x + (building.width / 2f);
    }

    void Update()
    {
        if(player.position.x + spawnDistance > rightEdge)
        {
            SpawnBuilding();
        }
    }

    void SpawnBuilding()
    {
        GameObject prefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
        GameObject newBuilding = Instantiate(prefab);
        Building building = newBuilding.GetComponent<Building>();

        float gap = Random.Range(minGap, maxGap);

        float spawnX = rightEdge + gap + (building.width / 2f);
        newBuilding.transform.position = new Vector3(spawnX, 0, 0);

        rightEdge = spawnX + (building.width / 2f);
    }
}