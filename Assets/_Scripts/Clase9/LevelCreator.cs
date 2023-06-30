using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] GameObject[] PrefabCube;
    [SerializeField] Vector3 TamanoTerreno;
    [SerializeField] Vector3 Posicion;
    [SerializeField] float[] alturas;

    public float detalle;
    float detalleFino;

    void Start()
    {
        alturas = new float[(int)TamanoTerreno.x * (int)TamanoTerreno.z];

        for(int i = 0; i < TamanoTerreno.x * TamanoTerreno.z; i++)
        {
            int rng = Random.Range(0, PrefabCube.Length);
            Instantiate(PrefabCube[rng], Vector3.zero, Quaternion.Euler(0,0,0), transform);
        }


    }

    // Update is called once per frame
    void Update()
    {
        SetAlturas();
        ColocarCubos();
    }

    void SetAlturas()
    {
        detalleFino = detalle * 0.01f;

        for (float z = 0; z < TamanoTerreno.z; z++)
        {
            for (float x = 0; x < TamanoTerreno.x; x++)
            {
                alturas[(int)x + ((int)z * (int)TamanoTerreno.x)] = 
                Mathf.Floor(Mathf.PerlinNoise(x * detalleFino, z * detalleFino) * 10);
            }
        }
                
    }

    void ColocarCubos()
    {
        int i = 0;

        for(Posicion.z = 0; Posicion.z < TamanoTerreno.z; Posicion.z++)
        {
            for(Posicion.x = 0; Posicion.x < TamanoTerreno.x; Posicion.x++)
            {
                Posicion.y = alturas[(int)Posicion.x + ((int)Posicion.z * (int)TamanoTerreno.x)];

                transform.GetChild(i).localPosition = Posicion;
                i++;
            }
        }
    }
}
