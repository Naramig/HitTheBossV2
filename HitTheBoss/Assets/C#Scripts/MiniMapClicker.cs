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
    public GameObject target;
    
    Player player;

    private void Start()
    {

        player = FindObjectOfType<Player>();
    }


    public bool mapIsOpen = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mapIsOpen)
        {
            Vector2 localCursor = new Vector2(0, 0);
            target = null;
            
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RawImage>().rectTransform, eventData.pressPosition, eventData.pressEventCamera, out localCursor))
            {

                Texture tex = GetComponent<RawImage>().texture;
                Rect r = GetComponent<RawImage>().rectTransform.rect;

                //Using the size of the texture and the local cursor, clamp the X,Y coords between 0 and width - height of texture
                float coordX = Mathf.Clamp(0, (((localCursor.x - r.x) * tex.width) / r.width), tex.width);
                float coordY = Mathf.Clamp(0, (((localCursor.y - r.y) * tex.height) / r.height), tex.height);

                //Convert coordX and coordY to % (0.0-1.0) with respect to texture width and height
                float recalcX = coordX / tex.width;
                float recalcY = coordY / tex.height;

                localCursor = new Vector2(recalcX, recalcY);

                CastMiniMapRayToWorld(localCursor);
                
                if (target.name == "TransitionPoint")
                {
                 
                    player.GetComponent<AIDestinationSetter>().target = miniMapHit.collider.gameObject.transform;
                    
                    mapIsOpen = false;
                }
            }
        }

    }



    private void CastMiniMapRayToWorld(Vector2 localCursor)
    {
        Ray miniMapRay = miniMapCam.ScreenPointToRay(new Vector2(localCursor.x * miniMapCam.pixelWidth, localCursor.y * miniMapCam.pixelHeight));


        if (Physics.Raycast(miniMapRay, out miniMapHit, Mathf.Infinity))
        {
            
            target = miniMapHit.collider.gameObject;
            

        }

    }


}