
public sealed class SceneMessage : MessageBase
{
    public readonly string SceneName;

    public SceneMessage(string sceneName)
    {
        SceneName = sceneName;
    }
}
