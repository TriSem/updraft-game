using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Systems/EnemyRecorder")]
public class EnemyRecorder : ScriptableObject
{
    Dictionary<Transform, Queue<EnemyState>> enemyData;
    
    public bool Initialized { get; private set; }

    public int RecordsPerEnemy { get; set; }

    public void Initialize(Transform[] enemyTransforms, int recordsPerEnemy)
    {
        if(enemyData == null)
            enemyData = new Dictionary<Transform, Queue<EnemyState>>();

        if(Initialized)
            Clear();

        RecordsPerEnemy = recordsPerEnemy;
        foreach(Transform t in enemyTransforms)
        {
            enemyData.Add(t, new Queue<EnemyState>());
        }

        Initialized = true;
    }

    public void Clear()
    {
        if(Initialized)
        {
            enemyData.Clear();
            Initialized = false;
        }
    }

    /** Queues a new saved state for
    each enemy and removes superfluous
    states. */
    public void SaveEnemyStates()
    {
        if(enemyData.Count == 0)
            return;
        
        EnemyState state = new EnemyState();

        foreach(var entry in enemyData)
        {
            var enemyTransform = entry.Key;
            state.isActive = enemyTransform.gameObject.activeInHierarchy;
            state.position = enemyTransform.localPosition;
            state.rotation = enemyTransform.localRotation;
            state.scale = enemyTransform.localScale;    
            
            if(entry.Value.Count > RecordsPerEnemy)
                entry.Value.Dequeue();

            entry.Value.Enqueue(state);
        }
    }

    public void Rewind(int rewindSeconds)
    {
        EnemyState state;
        Transform t;

        foreach(var entry in enemyData)
        {
            // Skip enemies that are already 
            // out of (or not yet) in rewind range.
            if(!entry.Value.Peek().isActive)
                continue;

            t = entry.Key;

            state = entry.Value.ToArray()[RecordsPerEnemy - rewindSeconds];
            t.gameObject.SetActive(state.isActive);
            t.localPosition = state.position;
            t.localRotation = state.rotation;
            t.localScale = state.scale;
        }
    }

    public void DisableColliders(bool disable)
    {
        foreach(var entry in enemyData)
        {
            Transform t = entry.Key;
            t.GetComponent<Collider>().enabled = disable;
        }
    }
}
