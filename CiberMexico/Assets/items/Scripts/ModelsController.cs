using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsController : MonoBehaviour
{
    public GameObject modelo1;
    public GameObject modelo2;
    public float radioDeAccion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (GPSController.distancia < radioDeAccion)
        {
            modelo2.SetActive(true);
            modelo1.SetActive(false);
        }
        else
        {
            modelo2.SetActive(false);
            modelo1.SetActive(true);
        }
    }
}
