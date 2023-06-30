using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public enum PuertaNecesaria {Puerta_norte_necesaria,
                                 Puerta_sur_necesaria,
                                 Puerta_derecha_necesaria,
                                 Puerta_izquierda_necesaria};
                                 
    public PuertaNecesaria _puerta_necesaria;

    int rng;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CrearHabitacion", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(DungeonManager.Instance.MetaCreada == true)
            Invoke("CrearHabitacionCerrada", 0.1f);
    }

    void CrearHabitacion()
    {
        switch(_puerta_necesaria)
        {
            case PuertaNecesaria.Puerta_norte_necesaria:

            rng = Random.Range(0, DungeonManager.Instance.HabitacionesPuertaNorte.Length);

            Instantiate(DungeonManager.Instance.HabitacionesPuertaNorte[rng],
                        transform.position,
                        Quaternion.Euler(0,0,0));

            break;

            case PuertaNecesaria.Puerta_sur_necesaria:

            rng = Random.Range(0, DungeonManager.Instance.HabitacionesPuertaSur.Length);

            Instantiate(DungeonManager.Instance.HabitacionesPuertaSur[rng],
                        transform.position,
                        Quaternion.Euler(0,0,0));

            break;

            case PuertaNecesaria.Puerta_derecha_necesaria:

            rng = Random.Range(0, DungeonManager.Instance.HabitacionesPuertaDerecha.Length);

            Instantiate(DungeonManager.Instance.HabitacionesPuertaDerecha[rng],
                        transform.position,
                        Quaternion.Euler(0,0,0));

            break;

            case PuertaNecesaria.Puerta_izquierda_necesaria:

            rng = Random.Range(0, DungeonManager.Instance.HabitacionesPuertaIzquierda.Length);

            Instantiate(DungeonManager.Instance.HabitacionesPuertaIzquierda[rng],
                        transform.position,
                        Quaternion.Euler(0,0,0));

            break;
        }
    }

    void CrearHabitacionCerrada()
    {
        Instantiate(DungeonManager.Instance.habitacionCerrada,
                    transform.position,
                    Quaternion.Euler(0,0,0));

        Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Spawn Point"))
        {
            int MyId = gameObject.GetInstanceID();
            int OtherId = other.gameObject.GetInstanceID();

            if(MyId > OtherId)
                Invoke("CrearHabitacionCerrada", 0.1f);
            else 
                Destroy(gameObject);
        }

        else
            Destroy(gameObject);
    }
}
