using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelPieces;         // Prefabs
    [SerializeField] private Vector3 _nextPos;                  // Posicion siguiente
    [SerializeField] private int _amount;                       // Cantidad de prefabs utilizados

    [SerializeField] private GameObject _meta;

    private int _finalPiece;                                    // La ultima pieza para determinar la 'meta'

    private void Awake() {
        
        for (int i = 0; i < _amount; i++) {                     // Seguira instanciando prefabs hasta que llegue al limite

            int _rngPieces = Random.Range(0, 5);                // Genracion de un numero random, para definir cual de los 5 prefabs utilizar.

            Instantiate(_levelPieces[_rngPieces], 
                        _nextPos, 
                        Quaternion.Euler(0f, 0f, 0f));

            if (i != _amount - 1)
                _nextPos.x += 20;

            int _rngHeight = Random.Range(-5, 5);

            _nextPos.y = _rngHeight;

            if (i == _amount - 1) {

                _nextPos.y += 2;

                Instantiate(_meta, _nextPos, Quaternion.Euler(0f, 0f, 0f));
            }
        }

        
    }
}
