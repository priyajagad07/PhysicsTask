using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 10;
    public float forwardOffset = 3f;
    public float verticalOffset = 0f;

    void LateUpdate()
    {
        float targetX = player.position.x + forwardOffset;
        float targetY = player.position.y + verticalOffset;

        Vector3 targetPos = new Vector3(
            targetX,
            targetY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smoothSpeed * Time.deltaTime
        );
    }
}