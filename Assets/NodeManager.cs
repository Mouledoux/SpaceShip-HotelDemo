using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeManager : MonoBehaviour
{
    [SerializeField] List<TeleportNode> nodes;
    [SerializeField] SteamVR_TrackedController left;
    bool nodesEnabled = true;

    void Start()
    {
        ToggleNodes();
    }

    [ContextMenu("Add Nodes")]
    void SetNodes()
    {
        nodes = new List<TeleportNode>();
        var allNodes = FindObjectsOfType<TeleportNode>();
        foreach(TeleportNode n in allNodes)
        {
            n.gameObject.transform.parent = gameObject.transform;
            nodes.Add(n);
        }
    }

    public void ToggleNodes()
    {
        nodesEnabled = !nodesEnabled;

        foreach(TeleportNode n in nodes)
        {
            n.gameObject.SetActive(nodesEnabled);
        }
    }

    bool press = false;
    void Update()
    {
        if (left.triggerPressed)
        {
            if (press)
                return;
            ToggleNodes();
            press = true;
        }

        else
        {
            press = false;
        }
        
    }
}
