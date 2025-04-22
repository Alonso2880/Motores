using UnityEngine;
using TMPro;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; //Array de c�maras
    public TextMeshProUGUI cameraLabelText;
    private int currentCameraIndex = 0; //Contador de c�maras del array

    void Start()
    {
        ActivateCamera(currentCameraIndex);//Activa la c�mara inicial
    }

    public void SwitchToNextCamera() //Funci�n para cambiar de c�mara
    {
        currentCameraIndex++; //Suma 1 al contador
        if (currentCameraIndex >= cameras.Length) 
            //Si el numero del contador es mayor al numero de c�maras en el array
        {
            currentCameraIndex = 0; //Pone el contador en el inicio
        }

        ActivateCamera(currentCameraIndex); 
        //Llama a la funci�n ActivateCamera
    }

    void ActivateCamera(int index) //Funci�n para activar la c�mara seg�n
        //el n�mero del array
    {
        for (int i = 0; i < cameras.Length; i++) //Recorre el array
        {
            cameras[i].gameObject.SetActive(i == index); //Activa la c�mara
        }

        if (cameraLabelText != null)
        {
            //Pone el nombre de la c�mara en pantalla
            cameraLabelText.text = cameras[index].name; 
        }
    }
}