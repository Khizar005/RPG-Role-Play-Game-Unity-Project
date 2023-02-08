using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class LevelManager : MonoBehaviour
{
    private Vector3 bottomleftEdge;
    private Vector3 topRightEdge;

    [SerializeField] Tilemap tilemap;
    private void Start()
    {
        topRightEdge = tilemap.localBounds.max + new Vector3(-1, -1, 0);
        bottomleftEdge = tilemap.localBounds.min + new Vector3(1, 10, 0);

        Player.instance.SetLimit(bottomleftEdge,topRightEdge);
    }
}
