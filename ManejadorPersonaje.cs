using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManejadorPersonaje : MonoBehaviour{
    private const float rapidez= 3f;
    private Vector3 posicion; 
    private static ManejadorPersonaje manejadorActual;

     void Awake()
    {
        manejadorActual = this;
    }
    public static ManejadorPersonaje getManejadorPersonaje()
    {
        return manejadorActual;
    }
   public void setPosicionInicial(float posInicial)
    {
        this.posicion = new Vector3(posInicial + 2, 2, 4);
    }

    public float getRapidez()
    {
        return rapidez;
    }
    public Vector3 getPosicion (){
        return this.posicion;
    
    }
     public void setPosicion(Vector3 posicion){
        this.posicion=posicion;
    }
    public void moverPeronsajeX(){

        transform.position += (new Vector3(Camera.main.transform.forward.x, 0, 0)) * rapidez * Time.deltaTime;
    }
    public void moverPersonajeZ()
    {
        transform.position += (new Vector3(0, 0, Camera.main.transform.forward.z)) * rapidez * Time.deltaTime;
    }

}