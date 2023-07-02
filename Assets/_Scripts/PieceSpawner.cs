using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    internal enum PiezaNecesaria { _puertaEste, _puertaSur, _metaEste, _metaSur }

    [SerializeField] internal PiezaNecesaria _piezaNecesaria; 
    [SerializeField] private LevelPieces _levelPieces;

    public static int LimitePiezas;
    private static int _piezaAnterior;

    int _piezaRandom;

    private void Awake() {
       
        if (LimitePiezas <= 12f) {                                   // Cantidad de piezas a spawnear

            Invoke("SpawnNextPiece", 0.5f);
        }            
    }

    private void SpawnNextPiece() {
        
        switch (_piezaNecesaria) {

            case PiezaNecesaria._puertaEste:

                if (_levelPieces._canSpawnInEast) {

                    while (_piezaRandom == _piezaAnterior) {

                        _piezaRandom =  Random.Range(0, CreadorDeNivel.Instance._puertaEste.Length);
                        
                    } 

                    _piezaAnterior = _piezaRandom;                  // Recordar pieza anterior para evitar spawn de la misma pieza dos veces

                    Instantiate(CreadorDeNivel.Instance._puertaEste[_piezaRandom],
                                transform.position,
                                Quaternion.identity      
                               );

                    LimitePiezas++;
                }
            break;

            case PiezaNecesaria._puertaSur:

                if (_levelPieces._canSpawnInSouth) {

                    while (_piezaRandom == _piezaAnterior) {

                        _piezaRandom = Random.Range(0, CreadorDeNivel.Instance._puertaEste.Length);   
                                            
                    }

                    _piezaAnterior = _piezaRandom;                  // Recordar pieza anterior para evitar spawn de la misma pieza dos veces

                    Instantiate(CreadorDeNivel.Instance._puertaEste[_piezaRandom],
                                transform.position,
                                Quaternion.identity      
                               );

                    LimitePiezas++;
                }
            break;
        }
    }
}
