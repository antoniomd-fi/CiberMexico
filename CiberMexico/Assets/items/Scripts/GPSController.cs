using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSController : MonoBehaviour
{
    public float puntoLat;
    public float puntoLong;
    float actualLat;
    float actualLong;
    public static float distancia;

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

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        actualLat = Input.location.lastData.latitude;
        actualLong = Input.location.lastData.longitude;

        distancia = FormulaHaversine(puntoLat, puntoLong, actualLat, actualLong);
    }

    private void OnGUI()
    {
        string mensaje = "Latitud : " + actualLat +
                         "\nLongitud : " + actualLong +
                         "\nDistancia :" + distancia;

        GUI.contentColor = Color.red;
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(100, 80, 1000, 1000), mensaje);
    }
}
