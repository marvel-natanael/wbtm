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

    public EntitySubject SpawnEntity(Action onFinish)
    {
        EntitySubject entity = Instantiate(_entity, transform.position, Quaternion.identity, _entityParent);
        entity.OnSpawn(_destination, onFinish);
        return entity;
    }
}
