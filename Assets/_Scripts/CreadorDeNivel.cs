using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDeNivel : MonoBehaviour
{
    [SerializeField] private GameObject _final;
    [SerializeField] private GameObject[] _piezas;
    [SerializeField] private int _cantidadPiezas;

    [SerializeField] private Vector3 _nuevaPosicion;

    [SerializeField] private GameObject _puntoInicio;
    [SerializeField] private GameObject _puntoFinal;
    [SerializeField] private Objects Instance;

    /*  LO HARE EN HORIZONTAL
         __ __ __ __
inicio->|__|__|__|__|
        |__|__|__|__|
        |__|__|__|__|
        |__|__|__|__|<-final

    Random:
         __ __ __ __
        |_1|_2|__|__|
        |__|_3|__|__|
        |__|_4|_5|__|
        |__|__|_6|_7|

         __ __ __ __
        |_1|__|__|__|
        |_2|__|__|__|
        |_3|_4|_5|__|
        |__|__|_6|_7|

         __ __ __ __
        |_1|_2|_3|__|
        |__|__|_4|_5|
        |__|__|__|_6|
        |__|__|__|_7|    

    */

    private void Awake() {

        Instance = GetComponent<Objects>();
        
        
    }

    private void Start() {
        
        for (int i = 0; i < _cantidadPiezas; i++) {

            int _piezaRandom = Random.Range(0, 5);

            if (i == 0) {

                Instantiate(_piezas[_piezaRandom], _puntoInicio.transform.position, Quaternion.identity);
            }
            else if (i == 6) {

                Instantiate(_piezas[_piezaRandom], _puntoFinal.transform.position, Quaternion.identity);
            }
            else  {

                Instantiate(_piezas[_piezaRandom], Instance._nuevaPosicion, Quaternion.Euler(0f, 0f, 0f));
            }

            if (i == 6)
                Instantiate(_final, _nuevaPosicion, Quaternion.identity);

        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Limite")) {

            // Que no spawnee la pieza en la posicion del collider
        }
        else if (other.CompareTag("Spawnable")) {

            // Spawnear el objeto

            print("Spawnable object");

            _nuevaPosicion = other.transform.position;
        }
    }
}
