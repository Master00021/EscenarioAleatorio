using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPieces : MonoBehaviour
{
    [SerializeField] private GameObject _spawnEste;
    [SerializeField] private GameObject _spawnSur;

    public static int Randomizer;

    internal bool _canSpawnInEast;
    internal bool _canSpawnInSouth;

    private void Awake() {

        if (transform.position == new Vector3(transform.position.x, transform.position.y, -70f)) {              // Limite Sur

            _canSpawnInSouth = false;
        }
        else
            _canSpawnInSouth = true;

        if (transform.position == new Vector3(70f, transform.position.y, transform.position.z)) {               // Limite Este

            _canSpawnInEast = false;
        }
        else
            _canSpawnInEast = true;

        if (_canSpawnInEast == _canSpawnInSouth) {                  // Mientras sea posible spawnear en ambas posiciones, elegir una de las dos aleatoriamente

            int rng = Random.Range(0, 10);


            if (rng >= 0 && rng <= 5)
                _canSpawnInEast = false;
            else
                _canSpawnInSouth = false;
        }
        
        Randomizer = Random.Range(0, 10);

        if (Randomizer >= 0 && Randomizer <= 5 && _canSpawnInEast == false) {

            Destroy(_spawnEste.gameObject);                         // Eliminar el SpawnPoint para evitar que se creen dos piezas de nivel al mismo tiempo
        }
            
        else if (_canSpawnInSouth == false) {

            Destroy(_spawnSur.gameObject);                          // Eliminar el SpawnPoint para evitar que se creen dos piezas de nivel al mismo tiempo
        }
    }

    private void Start() {

        CreadorDeNivel.Instance._piezasCreadas.Add(this.gameObject);
    }
}
