using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Prefabs
    public GameObject ring;
    public GameObject pieceOfThePlatform;
    public GameObject player;

    private GameObject platform;
    private GameObject playerClone;

    //Materials
    public Material lightPlatformMaterial;

    //Used for rings
    float ringPositionOnZAxes = 13.5f;
    float[] distancesForRings = new float[3] { 4.5f, 9f, 13.5f };
    int initialRingCount = 10;

    //Used for platform pieces
    readonly float extraPlatformSpace = 9f;

    private void Start()
    {
        platform = new GameObject("Platform");

        for (int i = 0; i < initialRingCount; i++)
        {
            //Instantiate rings with random distances
            GameObject ringClone = Instantiate(ring) as GameObject;
            ringClone.transform.position = new Vector3(Random.Range(-1, 2), ringClone.transform.position.y, ringPositionOnZAxes);
            ringPositionOnZAxes += distancesForRings[Random.Range(0, distancesForRings.Length)];

            //Instantiate platform pieces relative to rings instantiated
            float zValueForPlatformPiece = 0f;
            while (zValueForPlatformPiece != ringClone.transform.position.z + extraPlatformSpace)
            {
                GameObject pieceOfThePlatformClone = Instantiate(pieceOfThePlatform) as GameObject;
                pieceOfThePlatformClone.transform.position = Vector3.forward * zValueForPlatformPiece;

                //Makes one of each two platform pieces have lighter material 
                if (pieceOfThePlatformClone.transform.position.z % 3f == 0)
                {
                    pieceOfThePlatformClone.GetComponent<MeshRenderer>().material = lightPlatformMaterial;
                }

                pieceOfThePlatformClone.transform.SetParent(platform.transform);
                zValueForPlatformPiece += 1.5f;
            }
        }

        playerClone = Instantiate(player) as GameObject;

        //After the player prefab instantiate into the scene add CameraFollow script to Camera
        GameObject.FindWithTag("MainCamera").AddComponent<CameraFollow>();

        //After the player prefab instantiate into the scene add Controls script to Controls object
        GameObject.FindWithTag("controlManager").AddComponent<ControlManager>();
    }
}
