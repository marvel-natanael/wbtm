using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityModelController : MonoBehaviour
{
    public int BadEntitiesInside { get; private set; }

    private List<EntityModelSO> entities = new List<EntityModelSO>();

    public void AddEntity(EntityModelSO entity)
    {
        entities.Add(entity); 
    } 

    public void ProcessEntity()
    {
        BadEntitiesInside = entities.Count(e => e.IsBad);
    }

    public void TestAddEntity()
    {
        var entity = new EntityModelSO();
        entity.IsBad = Random.Range(0, 2) > 0;
        AddEntity(entity);
    } 
}
