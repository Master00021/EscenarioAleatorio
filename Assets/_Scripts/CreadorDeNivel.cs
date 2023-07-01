using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreadorDeNivel : MonoBehaviour
{
    public static CreadorDeNivel Instance;

    [SerializeField] internal GameObject[] _puertaEste;              // Prefabs que sean compatibles con esta puerta
    [SerializeField] internal GameObject[] _puertaSur;               // Prefabs que sean compatibles con esta puerta

    [SerializeField] internal List<GameObject> _piezasCreadas;

    [SerializeField] private GameObject _meta;                       // Meta
    [SerializeField] private float _delaySpawnMeta;                  // Esperar a que se hayan spawneado todas las piezas

    private bool _metaCreada;

    private void Awake() {

        Instance = this;
        
        Invoke("SpawnMeta", _delaySpawnMeta);
    }

    private void SpawnMeta() {

        _metaCreada = true;

        Instantiate(_meta, _piezasCreadas[_piezasCreadas.Count - 1].transform.position, Quaternion.Euler(0f, 45f, 0f));
    }
}
