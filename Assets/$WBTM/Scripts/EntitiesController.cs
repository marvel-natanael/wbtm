using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    public int BadEntitiesInside { get; private set; }

    private List<EntitiesModelSO> entities = new List<EntitiesModelSO>();

    public void AddEntity(EntitiesModelSO entity)
    {
        entities.Add(entity);
        Debug.Log(entity.name + " isBad " + entity.IsBad);
    }

    public void ProcessEntity()
    {
        BadEntitiesInside = entities.Count(e => e.IsBad);
    }

    public void TestAddEntity()
    {
        var entity = new EntitiesModelSO();
        entity.IsBad = Random.Range(0, 2) > 0;
        AddEntity(entity);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 50, 150, 50), "Test Add Entity"))
        {
            for (int i = 0; i < 10; i++)
                TestAddEntity();
        }
    }
}
