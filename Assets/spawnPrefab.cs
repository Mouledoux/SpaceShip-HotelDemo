using UnityEngine;
using System.Collections;

public class spawnPrefab : MonoBehaviour
{
    public GameObject prefab;

    [ContextMenu("Spawn Prefab Object")]
    public void SpawnObject()
    {
        GameObject g = Instantiate(prefab);
        g.transform.parent = gameObject.transform;
        g.transform.localPosition = Vector3.zero;
    }

}
