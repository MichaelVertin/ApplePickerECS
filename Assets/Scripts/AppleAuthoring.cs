using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class AppleAuthoring : MonoBehaviour
{
    void createApple()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(Transform),
            typeof(RenderMesh),
            typeof(RenderBounds),
            typeof(LocalToWorld)
            );
        Entity myEntity = entityManager.CreateEntity(archetype);

        /*
        entityManager.AddComponentData(myEntity, new Transform
        {
            Value = new float3(2f, 0f, 4f)
        });
        */
    }

    private class AppleBaker : Baker<AppleAuthoring>
    {
        public override void Bake(AppleAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new AppleTreeProperties
            {
            };

            AddComponent(entity, propertiesComponent);
        }
    }

}

public struct Apple : IComponentData
{

}