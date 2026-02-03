using UnityEngine;

 
public class EntityModel 
{
    public VisualDescriptionModelSO HeadDescription;
    public VisualDescriptionModelSO ClothDescription;
    public VerbalDescriptionModelSO VoiceDescription;

    public override bool Equals(object obj)
    {
        if (obj is EntityModel other)
        {
            return HeadDescription == other.HeadDescription &&
                   ClothDescription == other.ClothDescription &&
                   VoiceDescription == other.VoiceDescription;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (HeadDescription, ClothDescription, VoiceDescription).GetHashCode();
    }
}