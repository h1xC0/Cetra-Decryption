using UnityEngine;

namespace SpawnPoints
{
    public interface ISpawnPoint
    { 
        Vector3 GetPosition();
        Transform GetSpawnParent();
    }
}