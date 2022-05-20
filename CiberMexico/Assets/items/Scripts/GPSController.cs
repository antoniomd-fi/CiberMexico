using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GPSController : MonoBehaviour
{
    private string urlMap="";
    public RawImage imageMap;
    public Text latitudText;
    public Text longitudText;
    public Text GPSStatus;
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
        }
        else
        {
            //  Servicio detenido
            GPSStatus.text = "Stop";

        } 
    }

    
}
