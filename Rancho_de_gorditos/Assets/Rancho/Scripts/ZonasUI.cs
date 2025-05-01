using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ZonasUI : MonoBehaviour
{
    public Canvas c;
    public TextMeshProUGUI Rancho;
    public TextMeshProUGUI Bosque;
   [HideInInspector] public bool rancho = false, bosque = false;
    private float tiempo = 5f;
    
    void Start()
    {
        c.enabled = false;
        Rancho.enabled = false;
        Bosque.enabled = false;
    }

  
    void Update()
    {
        if (rancho)
        {
            StartCoroutine(RanchoI(tiempo));
            
        }

        if(bosque)
        {
            StartCoroutine(BosqueI(tiempo));
        }
        
    }

    private IEnumerator RanchoI(float tiempo)
    {

        c.enabled=true;
        Rancho.enabled=true;
        yield return new WaitForSeconds(tiempo);
        c.enabled=false;
        Rancho.enabled = false;
        rancho = false;
    }

    private IEnumerator BosqueI(float tiempo)
    {
        c.enabled = true;
        Bosque.enabled=true;
        yield return new WaitForSeconds(tiempo);
        c.enabled = false;
        Bosque.enabled=false;
        bosque = false;
    }
}
