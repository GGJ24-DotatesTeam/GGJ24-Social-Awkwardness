using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float hoverHeight = 30f;
    public float speed = 5f;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Image cardImage;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition;
        cardImage = GetComponent<Image>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetPosition = originalPosition + new Vector3(0, hoverHeight, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetPosition = originalPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        cardImage.color = new Color32(0xC8, 0xC8, 0xC8, 0xFF);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        cardImage.color = Color.white;
    }

}
