using System;
using UnityEngine;

public class EntitySubjectController : MonoBehaviour
{
    [SerializeField]
    private EntitySubject _entity;
    [SerializeField]
    private Transform _entityParent;
    [SerializeField]
    private Transform _destination;

    public EntitySubject SpawnEntity(EntityModel entityModel, Action onFinish)
    {
        EntitySubject entity = Instantiate(_entity, transform.position, Quaternion.identity, _entityParent);
        entity.OnSpawn(entityModel, _destination, onFinish);
        return entity;
    }
}
