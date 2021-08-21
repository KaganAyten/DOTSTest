using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;
using UnityEngine.UI;
public class CapsuleManager : MonoBehaviour
{
    [SerializeField] GameObject CapsulePrefab;
    [SerializeField] GameObject button;
    [SerializeField] InputField height;
    [SerializeField] InputField width;
    BlobAssetStore blobAssetStore = new BlobAssetStore();
    public void CreateEntitites()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);

        Entity capsuleEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(CapsulePrefab, settings);

        for (int i = 0; i < int.Parse(width.text); i++)
        {
            for (int j = 0; j < int.Parse(height.text); j++)
            {
                Entity capsuleTemp = entityManager.Instantiate(capsuleEntity);
                Translation capsuleTranslation = new Translation
                {
                    Value = new float3(-75 + i, 2, -125 + j)
                };
                CapsuleComponent speedSettings = new CapsuleComponent
                {
                    speed = 5
                };
                entityManager.SetComponentData(capsuleTemp, capsuleTranslation);
                entityManager.AddComponent(capsuleTemp, typeof(CapsuleComponent));
                entityManager.SetComponentData(capsuleTemp, speedSettings);
            }
        }
        button.SetActive(false);
        height.gameObject.SetActive(false);
        width.gameObject.SetActive(false);
    }
    void Start()
    {
        
    }
    private void OnDisable()
    {
        blobAssetStore.Dispose();
    }
}