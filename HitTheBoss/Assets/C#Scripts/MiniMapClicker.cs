using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Pathfinding;

public class MiniMapClicker : MonoBehaviour, IPointerClickHandler
{
    
    public Camera miniMapCam;
    public RaycastHit miniMapHit;
    public bool mapIsOpen;

    Player  player;

    private void Start()
    {
        mapIsOpen = false;
        player = FindObjectOfType<Player>();
    }


    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mapIsOpen)
        {
            Vector2 localCursor = new Vector2(0, 0);
            
            
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RawImage>().rectTransform, eventData.pressPosition, eventData.pressEventCamera, out localCursor))
            {

                Texture tex = GetComponent<RawImage>().texture;
                Rect r = GetComponent<RawImage>().rectTransform.rect;

                float coordX = Mathf.Clamp(0, (((localCursor.x - r.x) * tex.width) / r.width), tex.width);
                float coordY = Mathf.Clamp(0, (((localCursor.y - r.y) * tex.height) / r.height), tex.height);

                float recalcX = coordX / tex.width;
                float recalcY = coordY / tex.height;

                localCursor = new Vector2(recalcX, recalcY);

                CastMiniMapRayToWorld(localCursor);
                

            }
        }

    }



    private void CastMiniMapRayToWorld(Vector2 localCursor)
    {
        Ray miniMapRay = miniMapCam.ScreenPointToRay(new Vector2(localCursor.x * miniMapCam.pixelWidth, localCursor.y * miniMapCam.pixelHeight));


        if (Physics.Raycast(miniMapRay, out miniMapHit, Mathf.Infinity))
        {

            if (miniMapHit.collider.gameObject.name == "TransitionPoint")
            {

                player.GetComponent<AIDestinationSetter>().target = miniMapHit.collider.gameObject.transform;

                mapIsOpen = false;
            }


        }

    }


}