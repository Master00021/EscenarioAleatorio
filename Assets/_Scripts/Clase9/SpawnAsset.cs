using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsset : MonoBehaviour
{
    public GameObject[] listaAssets;

    void Start()
    {
        Invoke("Spawn", 0.5f);
    }

    void Spawn()
    {
        int rng = Random.Range(0, listaAssets.Length);
        Instantiate(listaAssets[rng], 
                    transform.position + Vector3.up, 
                    Quaternion.Euler(0,0,0),
                    transform);
    }
}
