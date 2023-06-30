using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance;

    public GameObject[] HabitacionesPuertaNorte;
    public GameObject[] HabitacionesPuertaSur;
    public GameObject[] HabitacionesPuertaDerecha;
    public GameObject[] HabitacionesPuertaIzquierda;

    [Space(5)]

    public GameObject habitacionCerrada;
    public List<GameObject> HabitacionesCreadas;

    public GameObject Meta;
    public float DelayMeta;
    public bool MetaCreada = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        Invoke("CrearMeta", DelayMeta);
    }

    void CrearMeta()
    {
        Instantiate(Meta,
                    HabitacionesCreadas[HabitacionesCreadas.Count - 1].transform.position,
                    Quaternion.Euler(0,0,0));
                    
        MetaCreada = true;
    }
}
