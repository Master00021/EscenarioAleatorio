using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    [field: SerializeField] int[ , ] matriz = new int[4,4];



    /*
          0   1   2   3
      0 |0,0|0,1|0,2|0,3|   0, 1, 2, 3
      1 |1,0|1,1|1,2|1,3|   4, 5, 6, 7
      2 |2,0|2,1|2,2|2,3|   8, 9, 10, 11
      3 |3,0|3,1|3,2|3,3|   12, 13, 14, 15

    */

    private void Awake() {

    }
}
