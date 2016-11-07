using UnityEngine;
using System.Collections;

public class TeleportNode : MonoBehaviour
{
    public Vector3 teleportPos;

    void Start()
    {
        teleportPos = transform.position;
    }
}
