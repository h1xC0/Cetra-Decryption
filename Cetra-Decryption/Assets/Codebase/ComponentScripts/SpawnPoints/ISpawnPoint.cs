using UnityEngine;

namespace Codebase.ComponentScripts.SpawnPoints
{
    public interface ISpawnPoint
    { 
        Vector3 GetPosition();
        Transform GetSpawnParent();
    }
}