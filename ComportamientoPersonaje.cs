using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoPersonaje : MonoBehaviour
{
    private ManejadorPersonaje mp;
    private const float posY = 1.965f;
    private const float segParaCambiarHab = 2f;
    private float segIzq = 0;
    private float segDer = 0;
    private ManejadorCamarasOtros auxiliar;
    // Update is called once per frame
    private void Start()
    {
        auxiliar = GameObject.Find("CodigosModoUtilizacion").GetComponent<ManejadorCamarasOtros>();
    }
    void Update()
    {
        if ((Camera.main.transform.position.y < posY))
        {
            mp = ManejadorPersonaje.getManejadorPersonaje();
            if (!fueraDeLosLimitesX())
            {
                mp.moverPeronsajeX();
                segIzq = 0;
                segDer = 0;
            }
            if (!fueraDeLosLimitesZ())
            {
                mp.moverPersonajeZ();
                segIzq = 0;
                segDer = 0;
            }
        }
        if (cambiarSigHabitacion())
        {
            segIzq = 0;
            segDer = 0;
            auxiliar.manejadorBotonHabitacionSiguiente();
        }
        if (cambiarHabitacionAnt())
        {
            segIzq = 0;
            segDer = 0;
            auxiliar.manejadorBotonHabitacionAnterior();
        }
    }

  

    private bool fueraDeLosLimitesX()
    {
        Habitacion habAct = HabitacionActual.getHabitacionActual();
        int ancho= habAct.ancho;
        int largo = habAct.largo;
        if (Camera.main.transform.position.x < 1 || Camera.main.transform.position.x >= ancho-1) return true;
        return false;
    }

    private bool fueraDeLosLimitesZ()
    {
        Habitacion habAct = HabitacionActual.getHabitacionActual();
        int ancho = habAct.ancho;
        int largo = habAct.largo;
        if (Camera.main.transform.position.z < 1 || Camera.main.transform.position.z >= largo - 1) return true;
        return false;
    }

    private bool cambiarSigHabitacion()
    {
        Habitacion habAct = HabitacionActual.getHabitacionActual();
        int ancho = habAct.ancho;
        if (Camera.main.transform.position.x >= ancho - 1)
        {
            segIzq += Time.deltaTime;
            if (segIzq >= segParaCambiarHab) return true;
        }
        return false;
    }
    private bool cambiarHabitacionAnt()
    {
        if (Camera.main.transform.position.x < 1)
        {
            segDer += Time.deltaTime;
            if (segDer >= segParaCambiarHab) return true;
        }
        return false;
    }
}
