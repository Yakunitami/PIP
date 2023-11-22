using Godot;

public partial class LabelChanger : RichTextLabel
{
    [Export]
    public NodePath AnimationPlayerPath = new NodePath();

    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        base._Ready();

        this.Text = Texts.GetTextFromId(0);
       
        _animationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);

        _animationPlayer.Play("showtext");
    }

    private void ChangeText(Texts.TextsVariant id)
    {
        this.Text = Texts.GetTextFromId(id);

        _animationPlayer.Stop();
        _animationPlayer.Play("showtext");
    }

    private void ChangeToScene(ScenesPath.NodePathVariants id)
    {
        GetTree().ChangeSceneToFile(ScenesPath.GetPathFromId(id));
    }
}
