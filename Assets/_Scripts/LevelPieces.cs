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

        if (transform.position == new Vector3(transform.position.x, transform.position.y, -70f)) {

            _canSpawnInSouth = false;
        }
        else
            _canSpawnInSouth = true;

        if (transform.position == new Vector3(70f, transform.position.y, transform.position.z)) {

            _canSpawnInEast = false;
        }
        else
            _canSpawnInEast = true;

        if (_canSpawnInEast == _canSpawnInSouth) {

            int rng = Random.Range(0, 10);


            if (rng >= 0 && rng <= 5)
                _canSpawnInEast = false;
            else
                _canSpawnInSouth = false;
        }
        
        Randomizer = Random.Range(0, 10);

        if (Randomizer >= 0 && Randomizer <= 5 && _canSpawnInEast == false) {

            Destroy(_spawnEste.gameObject);
        }
            
        else if (_canSpawnInSouth == false) {

            Destroy(_spawnSur.gameObject);
        }
    }

    private void Start() {

        CreadorDeNivel.Instance._piezasCreadas.Add(this.gameObject);
    }
}
