using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsController : MonoBehaviour
{
    public GameObject modelo1;
    public GameObject modelo2;
    public float radioDeAccion;
    public Text title;
    public Text info;
    public GameObject InfoButton;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (GPSController.distancia < radioDeAccion)
        {
            modelo1.SetActive(false);
            modelo2.SetActive(true);
            InfoButton.SetActive(true);
            title.text = "Xochipilli";
            info.text = "En la cultura mexica es el dios del amor, los juegos, la belleza, las flores, el maíz, el placer y de la ebriedad sagrada; su nombre significa Príncipe de las flores o Noble florido, aunque también puede ser interpretada como flor preciosa o flor noble.\n Su culto se relaciona con el de otros dioses del maíz,de la fertilidad y de la cosecha, como el dios de la lluvia, Tláloc, y el del maíz, Cinteotl. Está asociado con Macuilxochitl (Cinco flores), dios de los juegos y las apuestas. Su hermana melliza era Xochiquétzal.";
        }
        else if (GPSController.distancia2 < radioDeAccion)
        {
            modelo1.SetActive(true);
            modelo2.SetActive(false);
            InfoButton.SetActive(true);
            title.text = "Xochipilli";
            info.text = "En la cultura mexica es el dios del amor, los juegos, la belleza, las flores, el maíz, el placer y de la ebriedad sagrada; su nombre significa Príncipe de las flores o Noble florido, aunque también puede ser interpretada como flor preciosa o flor noble.\n Su culto se relaciona con el de otros dioses del maíz,de la fertilidad y de la cosecha, como el dios de la lluvia, Tláloc, y el del maíz, Cinteotl. Está asociado con Macuilxochitl (Cinco flores), dios de los juegos y las apuestas. Su hermana melliza era Xochiquétzal.";
            
        }
       else
       {
           modelo1.SetActive(false);
           modelo2.SetActive(false);
       }
    }
}
