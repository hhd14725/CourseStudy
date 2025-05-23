using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUIManager : MonoBehaviour
{
    public PlayerBuffHandler buffHandler;
    public GameObject buffEntryPrefab;

    public Transform buffContainer;

    private Dictionary<BuffData, BuffEntry> entries = new Dictionary<BuffData, BuffEntry>();

    private void Start()
    {
        buffHandler.OnBuffStart += CreateEntry;
        buffHandler.OnBuffEnd += RemoveEntry;
    }

    private void CreateEntry(BuffData buff)
    {
        if (entries.ContainsKey(buff))
            return;
        Debug.Log("버프아이콘 생성");
        GameObject go = Instantiate(buffEntryPrefab, buffContainer);
        BuffEntry entry = go.GetComponent<BuffEntry>();
        entry.Initialize(buff);
        entries.Add(buff, entry);
    }

    private void RemoveEntry(BuffData buff)
    {
        if (!entries.ContainsKey(buff)) return;
        Destroy(entries[buff].gameObject);
        entries.Remove(buff);
    }
}
