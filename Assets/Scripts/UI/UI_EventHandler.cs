using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> onBeginDragHandler = null;
    public Action<PointerEventData> onDragHandler = null;
    public Action<PointerEventData> onPointerClick = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDragHandler != null)
        {
            onBeginDragHandler.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(onDragHandler != null)
        {
            onDragHandler.Invoke(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(onPointerClick != null)
        {
            onPointerClick.Invoke(eventData);
        }
    }
}
