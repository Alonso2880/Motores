using UnityEngine;
using TMPro;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public TextMeshProUGUI cameraLabelText;
    private int currentCameraIndex = 0;

    void Start()
    {
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToNextCamera()
    {
        currentCameraIndex++;
        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }

        ActivateCamera(currentCameraIndex);
    }

    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }

        if (cameraLabelText != null)
        {
            cameraLabelText.text = cameras[index].name;
        }
    }
}