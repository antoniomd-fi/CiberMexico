using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GPSController : MonoBehaviour
{
    public Text latitudText;
    public Text longitudText;
    public Text GPSStatus;
    public Text dist1;
    public Text dist2;
    public Text dist3;
    public float puntoLat;
    public float puntoLong;
    public float puntoLat2;
    public float puntoLong2;
    public float puntoLat3;
    public float puntoLong3;
    float actualLat;
    float actualLong;
    public static float distancia;
    public static float distancia2;
    public static float distancia3;
    void Start()
    {
        StartCoroutine(GetMap());
    }

    IEnumerator GetMap()
    {
        // Verificar si el servicio de ubicación está activado
        if (!Input.location.isEnabledByUser)
            yield break;
        // iniciar servicio
        Input.location.Start();
        // Esperar hasta que se inicie el servicio
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // 20 segundos para iniciar el servicio
        if (maxWait < 1)
        {
            GPSStatus.text = "Time Out";
            yield break;
        }

// Conexión fallida
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text="Unable to determine device location";

            yield break;
        }
        else
        {
            // Acceso garantizado
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData",0.5f,1f);

        }
    } 

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            // Obtener valores de GPS
            GPSStatus.text = "Running";
            latitudText.text = Input.location.lastData.latitude.ToString();
            longitudText.text = Input.location.lastData.longitude.ToString();
            actualLat = Input.location.lastData.latitude;
            actualLong = Input.location.lastData.longitude;
            distancia = FormulaHaversine(puntoLat, puntoLong,actualLat,actualLong);
            distancia2 = FormulaHaversine(puntoLat2, puntoLong2,actualLat,actualLong);
            distancia3 = FormulaHaversine(puntoLat3, puntoLong3,actualLat,actualLong);
            dist1.text = distancia.ToString();
            dist2.text = distancia2.ToString();
            dist3.text = distancia3.ToString();
        }
        else
        {
            //  Servicio detenido
            GPSStatus.text = "Stop";

        } 
    }
    
    float FormulaHaversine(float lat1, float long1, float lat2, float long2)
    {
        float earthRad = 6371000;
        float lRad1 = lat1 * Mathf.Deg2Rad;
        float lRad2 = lat2 * Mathf.Deg2Rad;
        float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
        float dLong = (long2 - long1) * Mathf.Deg2Rad;
        float a = Mathf.Sin(dLat / 2.0f) * Mathf.Sin(dLat / 2.0f) +
                  Mathf.Cos(lRad1) * Mathf.Cos(lRad2) *
                  Mathf.Sin(dLong / 2.0f) * Mathf.Sin(dLong / 2.0f);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return earthRad * c; //en metros
    }

    void Update()
    {
        
    }
    
}
