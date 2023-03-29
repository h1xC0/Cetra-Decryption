using System;
using UnityEngine;

namespace SpawnPoints
{
    public class SpawnPointBase : MonoBehaviour, ISpawnPoint
    {
        [SerializeField] private Transform _spawmParent;
        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Transform GetSpawnParent()
        {
            return _spawmParent ? _spawmParent : transform;
        }
    }
}