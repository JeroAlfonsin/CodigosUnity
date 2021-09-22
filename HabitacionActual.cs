using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitacionActual : MonoBehaviour
{
   private static Habitacion habitacionActual;

   public static void setHabitacionActual (Habitacion habitacion)
    {
        habitacionActual = habitacion;
    }

    public static Habitacion getHabitacionActual()
    {
        return habitacionActual;
    }

}
