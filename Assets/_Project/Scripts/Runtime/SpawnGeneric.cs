//
//  SpawnGeneric.cs
//  A basic script for spawning a duplicate of an object
//
//  Created by William Harris on 3/1/2026.
//  May god have mercy on my lactic acids

using Unity.Mathematics;
using UnityEngine;

public class SpawnGeneric : MonoBehaviour
{
    public GameObject prefab;
    public GameObject positionFinder;
    Vector3 spawnPosition;
    quaternion spawnRotation;

    private void Update()
    {
        spawnPosition = positionFinder.transform.position;
        spawnRotation = positionFinder.transform.rotation;
    }
    public void Spawn()
    {
        Instantiate(prefab, spawnPosition, spawnRotation);
    }
}
