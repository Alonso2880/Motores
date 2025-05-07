using UnityEngine;
using System.Collections.Generic;
public class HuertoManager : MonoBehaviour
{
    [Header("Prefabs de Plantas")]
    public GameObject semillaPrefab, brotePrefab, zanahoriaPrefab, patataPrefab;

    public float ySemilla = 0.551f;
    public float yBrote = 0.925f;
    public float yZanahoria = 1.199f;
    public float yPatata = 0.862f;

    [Header("Huecos de Plantación")]
    public List<Transform> huecos;

    private class HuecoEstado
    {
        public bool ocupado;
        public Planta planta;
    }

    private List<HuecoEstado> estados;
    private casa casaScript;
    

    private void Awake()
    {
        casaScript = Object.FindFirstObjectByType<casa>();

        estados = new List<HuecoEstado>(huecos.Count);
        for(int i =0; i<huecos.Count;i++)
        {
            estados.Add(new HuecoEstado());
        }
    }

    public bool PlantarSemilla(int tipo)
    {
        for (int i = 0; i < estados.Count; i++)
        {
            if (!estados[i].ocupado)
            {
                Transform hueco = huecos[i];

                // Crear contenedor vacío de la planta
                GameObject contenedor = new GameObject("PlantaContainer");
                contenedor.transform.SetParent(hueco);
                contenedor.transform.localPosition = Vector3.zero;
                contenedor.transform.localRotation = Quaternion.identity;

                // Determinar offset de fruto y prefab
                float offsetFruto = (tipo == (int)Planta.Tipo.Zanahoria) ? yZanahoria : yPatata;
                GameObject frutoPrefab = (tipo == (int)Planta.Tipo.Zanahoria) ? zanahoriaPrefab : patataPrefab;

                // Añadir componente Planta y pasar datos
                var planta = contenedor.AddComponent<Planta>();
                planta.Inicializar(
                    (Planta.Tipo)tipo,
                    semillaPrefab,
                    brotePrefab,
                    frutoPrefab,
                    casaScript,
                    ySemilla,
                    yBrote,
                    offsetFruto
                );

                estados[i].ocupado = true;
                estados[i].planta = planta;
                return true;
            }
        }
        Debug.Log("No hay huecos libres en el huerto.");
        return false;
    }


    void Update()
    {
        foreach (var st in estados)
            if (st.ocupado && st.planta != null)
                st.planta.ActualizarCrecimiento();
    }

    public List<Planta.Tipo> CosecharTodas()
    {
        List<Planta.Tipo> cosechadas = new List<Planta.Tipo>();
        for (int i = 0; i < estados.Count; i++)
        {
            var estado = estados[i];
            if (estado.ocupado && estado.planta.EstaCrecida())
            {
                cosechadas.Add(estado.planta.GetTipo());

                // Destruye el contenedor de la planta y libera el hueco
                Destroy(estado.planta.gameObject);
                estado.ocupado = false;
                estado.planta = null;
            }
        }
        return cosechadas;
    }
}
