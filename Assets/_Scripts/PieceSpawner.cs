using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    internal enum PiezaNecesaria { _puertaEste, _puertaSur, _metaEste, _metaSur }

    [SerializeField] internal PiezaNecesaria _piezaNecesaria;       // Randomizarla
    [SerializeField] private GameObject _metaEste;
    [SerializeField] private GameObject _metaSur;

    [SerializeField] private GameObject _puntoInicio;               // La posicion del primer prefab a spawnear
    [SerializeField] private GameObject _puntoFinal;                // La posicion del ultimo prefab a spawnear

    int _piezaRandom;
    public static int LimitePiezas;

    private Vector3 _downLimit = new Vector3();


    [SerializeField] private LevelPieces _levelPieces;

    private static int _piezaAnterior;


    private void Awake() {
       
        if (LimitePiezas <= 12f) {                                   // El limite debe ser segun la posicion del _puntoFinal

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

                    print(_piezaRandom);

                    _piezaAnterior = _piezaRandom;

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

                    print(_piezaRandom); 

                    _piezaAnterior = _piezaRandom;

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
