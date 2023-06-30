using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    public static Objects Instance;
    internal Vector3 _nuevaPosicion;

    private void Awake() {
        
        Instance = this;
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
