using Reflex.Attributes;
using Reflex.Core;
using Reflex.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ctx
{
    public static T Resolve<T>()
    {
        T result = SceneManager.GetActiveScene().GetSceneContainer().Resolve<T>();
        if (result == null)
            result = Container.RootContainer.Resolve<T>();
        return result;
    }
}