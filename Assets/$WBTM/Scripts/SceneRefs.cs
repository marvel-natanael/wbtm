using Eflatun.SceneReference;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneRefs", menuName = "WBTM/SceneRefs")]
public class SceneRefs : ScriptableObject
{
    [SerializeField]
    private SceneReference _menuScene;
    [SerializeField]
    private SceneReference _gameScene;
    [SerializeField]
    private SceneReference _endingScene;
    [SerializeField]
    private SceneReference _tutorialScene;
    public SceneReference GameScene => _gameScene;
    public SceneReference MenuScene => _menuScene;
    public SceneReference EndingScene => _endingScene;
    public SceneReference TutorialScene => _tutorialScene;
}
