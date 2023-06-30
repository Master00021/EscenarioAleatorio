using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHabitacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DungeonManager.Instance.HabitacionesCreadas.Add(this.gameObject);
    }
}
