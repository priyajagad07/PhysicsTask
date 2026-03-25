using UnityEngine;

public class Building : MonoBehaviour
{
    public float width;
    public float height;
    public Transform coinsParent;

    void Awake()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        Bounds bounds = renderers[0].bounds;

        foreach (Renderer r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }

        height = bounds.size.y;
        width = bounds.size.x;
    }
}
