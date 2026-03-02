//
//  SpawnGeneric.cs
//  A basic script for spawning a duplicate of an object
//
//  Created by William Harris on 3/1/2026.
//  May god have mercy on my lactic acids

using UnityEngine;

public class SpawnGeneric : MonoBehaviour
{
    public GameObject prefab;
    public Transform position;
    public void Spawn()
    {
        Instantiate(prefab, position);
    }
}
