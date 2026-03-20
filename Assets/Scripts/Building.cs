using UnityEngine;

public class Building : MonoBehaviour
{
    public float width;

    void Awake()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        Bounds bounds = renderers[0].bounds;

        foreach (Renderer r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }

        width = bounds.size.x;
    }
}
