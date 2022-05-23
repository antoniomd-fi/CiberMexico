using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsController : MonoBehaviour
{
    public GameObject modelo1;
    public GameObject modelo2;
    public GameObject modelo3;
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
            title.text = "Tlaloc";
            info.text = "Tláloc, dios de la lluvia,  deidad de los cerros, del agua y de la fertilidad. Según la cultura náhuatl, regía fenómenos meteorológicos como los relámpagos, los truenos, el granizo o las tormentas y, frecuentemente, se le asociaba a las cuevas.\n Sahagún señaló que este dios, Tláloc Tlamacazqui, era considerado habitante del paraíso terrenal y el responsable de dar a los hombres los mantenimientos necesarios para la vida.";
        }
        else if (GPSController.distancia2 < radioDeAccion)
        {
            modelo1.SetActive(true);
            modelo2.SetActive(false);
            InfoButton.SetActive(true);
            title.text = "Xochipilli";
            info.text = "En la cultura mexica es el dios del amor, los juegos, la belleza, las flores, el maíz, el placer y de la ebriedad sagrada; su nombre significa Príncipe de las flores o Noble florido, aunque también puede ser interpretada como flor preciosa o flor noble.\n Su culto se relaciona con el de otros dioses del maíz,de la fertilidad y de la cosecha, como el dios de la lluvia, Tláloc, y el del maíz, Cinteotl. Está asociado con Macuilxochitl (Cinco flores), dios de los juegos y las apuestas. Su hermana melliza era Xochiquétzal.";
            
        }
       else if (GPSController.distancia3 < radioDeAccion)
       {
           modelo1.SetActive(false);
           modelo2.SetActive(false);
           modelo3.SetActive(true);
           InfoButton.SetActive(true);
           title.text = "Xiuhcoatl";
           info.text = "Xiuhcoatl o Xiuhcóatl: ‘serpiente [de] fuego’, ‘serpiente sol[ar]’, ‘serpiente preciosa’ o ‘serpiente [de] jade’; es un arma viviente y la más poderosa de los dioses mexicas empuñada por el dios de la guerra Huitzilopochtli, con la cual mató a 400 de sus hermanos y a su hermana la diosa Coyolxauhqui. Mítica serpiente de fuego; se puede ver la representación de dos de estas criaturas en la Piedra del Sol.";
       }
       else
       {
           modelo1.SetActive(false);
           modelo2.SetActive(false);
           modelo3.SetActive(false);
           InfoButton.SetActive(false);
       }
    }
}
