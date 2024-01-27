using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image _image;
    private void Start()
    {
        _image = GetComponent<Image>();
    }
    
    public void SetProgress(float progress)
    {
        _image.fillAmount = progress;
    }
}
