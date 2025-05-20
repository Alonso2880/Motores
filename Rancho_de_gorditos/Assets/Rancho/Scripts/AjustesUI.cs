using UnityEngine;
using UnityEngine.UI;

public class AjustesUI : MonoBehaviour
{
    public Canvas can;
    public Button volver;
    private GameObject MP;
    public Slider volumen, brillo;
    
    public Image brightnessOverlay;
    private const string VolumeKey = "VolumenMaestro";
    private const string BrightnessKey = "BrilloEscena";

    void Start()
    {
        can.enabled = false;
        volver.onClick.AddListener(() => Volver());

        MP = GameObject.Find("MenuPausa");

        float volumenG = PlayerPrefs.GetFloat("VolumenMaestro", 0.5f);
        float brilloG = PlayerPrefs.GetFloat(BrightnessKey, 1f);
        volumen.value = volumenG;
        brillo.value = brilloG;



        volumen.onValueChanged.AddListener(SetVolumen);
        brillo.onValueChanged.AddListener(SetBrillo);

        SetVolumen(volumenG);
        SetBrillo(brilloG); 
    }

    public void SetVolumen(float v)
    {
        AudioListener.volume = v;
        PlayerPrefs.SetFloat("VolumenMaestro", v);
    }

    public void SetBrillo(float b)
    {
       if(brightnessOverlay != null)
        {
            float alpha = 1f - Mathf.Clamp01(b);
            brightnessOverlay.color = new Color(0f, 0f, 0f, alpha);
            PlayerPrefs.SetFloat(BrightnessKey, b);
        }
    }

    private void OnDestroy()
    {
        volumen.onValueChanged.RemoveListener(SetVolumen);
        brillo.onValueChanged.RemoveListener(SetBrillo);
    }

    void Update()
    {
        
    }

    public void inicio()
    {
        can.enabled = true;
    }

    private void Volver()
    {
        MenuPausaUI m = MP.GetComponent<MenuPausaUI>();

        can.enabled = false;
        m.c.enabled = true;
    }
}
