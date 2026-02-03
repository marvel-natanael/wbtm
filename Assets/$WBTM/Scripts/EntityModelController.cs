using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityModelController : MonoBehaviour
{
    private EntityModelCollection _entityModelCollection;
    private List<EntityModel> _entities = new List<EntityModel>();

    private EntityModelCollection EntityModelCollection {
        get {
            if (_entityModelCollection == null) _entityModelCollection = Ctx.Resolve<EntityModelCollection>();
            return _entityModelCollection;
        }
    }

    public int BadEntitiesInside { get; private set; }
    public List<EntityModel> PossibleEntities { get; private set; } = new List<EntityModel>();
    public List<EntityModel> BadEntities { get; private set; } = new List<EntityModel>();

    public List<EntityModel> GetPossibleEntities(int maxAmount, int badAmount)
    {
        if (maxAmount <= 0)
        {
            return new List<EntityModel>();
        }

        var heads = EntityModelCollection.HeadCollection;
        var cloths = EntityModelCollection.ClothCollection;
        var voices = EntityModelCollection.DialogCollection;

        var combinations = from h in heads
                           from c in cloths
                           from v in voices
                           select new EntityModel
                           {
                               HeadDescription = h,
                               ClothDescription = c,
                               VoiceDescription = v,
                           };

        var list = combinations.ToList(); 
        list = list.OrderBy(x => Random.value).ToList();
        PossibleEntities = list.Take(maxAmount).ToList();
         
        var shuffledPossible = PossibleEntities.OrderBy(x => Random.value).ToList();
        BadEntities = shuffledPossible.Take(Mathf.Min(badAmount, PossibleEntities.Count)).ToList();

        return PossibleEntities;
    }

    public void AddEntity(EntityModel entity)
    {
        _entities.Add(entity);
    }


    public bool IsBadEntity(EntityModel entity)
    {
        return BadEntities.Contains(entity);
    }

    public void ProcessEntity()
    {
        BadEntitiesInside = _entities.Count(e => BadEntities.Contains(e));
    }
}
