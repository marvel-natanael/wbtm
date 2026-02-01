using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityModelController : MonoBehaviour
{
    private EntityModelCollection _entityModelCollection => Ctx.Resolve<EntityModelCollection>();
    private List<EntityModelSO> entities = new List<EntityModelSO>();

    public int BadEntitiesInside { get; private set; }
    public List<EntityModelSO> PossibleEntities { get; private set; } = new List<EntityModelSO>();
    public List<EntityModelSO> BadEntities { get; private set; } = new List<EntityModelSO>();

    public List<EntityModelSO> GetPossibleEntities(int maxAmount, int badAmount)
    {
        if (maxAmount <= 0)
        {
            return new List<EntityModelSO>();
        }

        var heads = _entityModelCollection.HeadCollection;
        var cloths = _entityModelCollection.ClothCollection;
        var voices = _entityModelCollection.DialogCollection;

        var combinations = from h in heads
                           from c in cloths
                           from v in voices
                           select new EntityModelSO
                           {
                               HeadDescription = h,
                               ClothDescription = c,
                               VoiceDescription = v, 
                           };

        var list = combinations.ToList();
        // Shuffle the list to get random order
        list = list.OrderBy(x => Random.value).ToList();
        PossibleEntities = list.Take(maxAmount).ToList();

        // Get random entities as much as badAmount and add to BadEntities
        var shuffledPossible = PossibleEntities.OrderBy(x => Random.value).ToList();
        BadEntities = shuffledPossible.Take(Mathf.Min(badAmount, PossibleEntities.Count)).ToList();

        return PossibleEntities;
    }

    public void AddEntity(EntityModelSO entity)
    {
        entities.Add(entity);
    }

    public void ProcessEntity()
    {
        BadEntitiesInside = entities.Count(e => BadEntities.Any(b => b.HeadDescription == e.HeadDescription && b.ClothDescription == e.ClothDescription && b.VoiceDescription == e.VoiceDescription));
    } 
}
