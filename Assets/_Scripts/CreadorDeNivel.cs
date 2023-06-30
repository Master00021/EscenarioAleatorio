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
        
        for (int i = 0; i < _cantidadPiezas; i++) {

            int _piezaRandom = Random.Range(0, 5);

            Instantiate(_piezas[_piezaRandom], _nuevaPosicion, Quaternion.Euler(0f, 0f, 0f));

            _nuevaPosicion = new Vector3();

            if (i == _cantidadPiezas - 1)
                Instantiate(_final, _nuevaPosicion, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Pieza")) {

            int _myID = gameObject.GetInstanceID();
            int _otherID = gameObject.GetInstanceID();

            if (_myID > _otherID) {

                Destroy(other.gameObject, 5f);
            }
            else    
                Destroy(gameObject, 5f);
        }
    }
}
