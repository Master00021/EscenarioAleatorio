using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] GameObject[] levelPieces;
    [SerializeField] GameObject meta;
    [SerializeField] private int _cantidadpiezas;
    [SerializeField] private Vector3 _nextPosition;
    int _lastPiece;
    void Awake()
    {
        _lastPiece = _cantidadpiezas;

        for (int i = 0; i < _cantidadpiezas; i++) {    

            int _rngPieces = Random.Range(0, 5);

            print("for");

            while (_rngPieces == _lastPiece) {

                print("while");

                

                _rngPieces = Random.Range(0, 5);

                Instantiate(meta, _nextPosition, Quaternion.Euler(0f, 0f, 0f));
            }

            Instantiate(levelPieces[_rngPieces], _nextPosition, Quaternion.Euler(0f, 0f, 0f));

            _nextPosition.x += 20;
           
           int _rngHeight = Random.Range(-5, 5);

           _nextPosition.y = _rngHeight;

            _lastPiece = _rngPieces;
        } 
    }
}

