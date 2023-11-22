using Godot;

public static class ScenesPath
{
    private static NodePath s_gamePath = "res://scenes/game.tscn";
    private static NodePath s_walkGamePath = "res://scenes/WalkGame.tscn";
    private static NodePath s_mainMenuPath = "res://scenes/main.tscn";

    public enum NodePathVariants
    {
        GamePath,
        WalkGamePath,
        MainMenu,
    }

    public static string GetPathFromId(NodePathVariants id)
    {
        switch (id)
        {
        case NodePathVariants.GamePath:
            return s_gamePath;
        case NodePathVariants.WalkGamePath:
            return s_walkGamePath;
        default:
            return s_mainMenuPath;
        }
    }
}