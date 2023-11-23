using Godot;
using System;
using System.IO;
using System.Threading.Tasks;

public partial class game : Control
{
	[Export]
	public NodePath QuestionLabelPath = new NodePath();
	[Export]
	public NodePath LeftAnswerButtonPath = new NodePath();
	[Export]
	public NodePath RightAnswerButtonPath = new NodePath();
	[Export]
	public NodePath AnimationPlayerPath = new NodePath();
	[Export]
	public NodePath LeftAsnwerBtnLabelPath = new NodePath();
	[Export]
	public NodePath RightAsnwerBtnLabelPath = new NodePath();	
	[Export]
	public NodePath SoundPlayerPath = new NodePath();
	[Export]
	public AudioStream correctSound;
	[Export]
	public AudioStream incorrectSound;
	
	private Label _questionLabel;
	private TextureButton _leftAnswerButton;
	private TextureButton _rightAnswerButton;
	private AnimationPlayer _animationPlayer;
	private Label _leftAnswerBtnLabel;
	private Label _rightAnswerBtnLabel;
	private AudioStreamPlayer2D _soundPlayer;

	private QuizQuestion[] _quizQuestions;
	private int _currentQuestionIndex = 0;
	private int _score = 0;

	public override void _Ready()
	{
		base._Ready();
		
		_questionLabel = GetNode<Label>(QuestionLabelPath);
		_leftAnswerButton = GetNode<TextureButton>(LeftAnswerButtonPath);
		_rightAnswerButton = GetNode<TextureButton>(RightAnswerButtonPath);
		_animationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);
		_leftAnswerBtnLabel = GetNode<Label>(LeftAsnwerBtnLabelPath);
		_rightAnswerBtnLabel = GetNode<Label>(RightAsnwerBtnLabelPath);
		_soundPlayer = GetNode<AudioStreamPlayer2D>(SoundPlayerPath);

		_quizQuestions = new QuizQuestion[]
		{
			new QuizQuestion("В каком году была создана площадка?", new string[] {
				"2011",
				"2015"
			}, 0),
			new QuizQuestion("Входит ли технопарк в топ 10 технопарков России?", new string[] {
				"Да!",
				"Нет"
			}, 0),
			new QuizQuestion("Какие технологии присутствуют в нашем технопарке?", new string[]
			{
				"Бульдозеры",
				"3D-принтеры"
			},1)
		};

		Random rng = new();
		rng.Shuffle<QuizQuestion>(_quizQuestions);

		LoadRandomQuestion();
	}

	private void LoadRandomQuestion()
	{
		HandleButtonsStatus();

		QuizQuestion quizQuestion = _quizQuestions[_currentQuestionIndex];

		_questionLabel.Text = quizQuestion.Question;
		_leftAnswerBtnLabel.Text = quizQuestion.Answers[0];
		_rightAnswerBtnLabel.Text = quizQuestion.Answers[1];
	}

	private async void SubmitAnswer(int answerIndex)
	{
		int correctAnswerIndex = _quizQuestions[_currentQuestionIndex].AnswerIndex;

		HandleButtonsStatus(correctAnswerIndex);

		if (correctAnswerIndex == answerIndex)
		{
			_score++;
			_animationPlayer.Play("happy");
			_soundPlayer.Stream = correctSound;
			_soundPlayer.Play();
		}
		else
		{
			_soundPlayer.Stream = incorrectSound;
			_soundPlayer.Play();
		}
		await Task.Delay(TimeSpan.FromMilliseconds(2500));
		
		_currentQuestionIndex++;

		if (_currentQuestionIndex >= _quizQuestions.Length)
		{
			_questionLabel.Text = $"Спасибо за прохождение ;)\nВаш счёт: {_score}";
			HandleButtonsStatus();
			
			return;
		}

		LoadRandomQuestion();
	}

	private void HandleButtonsStatus(int correctAnswerIndex = -1)
	{	_leftAnswerButton.SelfModulate = new Color(1,1,1,1);
		_rightAnswerButton.SelfModulate = new Color(1,1,1,1);

		if (correctAnswerIndex >= 0)
		{
			_leftAnswerButton.SelfModulate = correctAnswerIndex == 0 ? new Color(0,1,0,1) : new Color(1,0,0,1);
			_rightAnswerButton.SelfModulate = correctAnswerIndex == 1 ? new Color(0,1,0,1) : new Color(1,0,0,1);
		}

		bool isButtonDisabled = correctAnswerIndex != -1;

		_leftAnswerButton.Disabled = isButtonDisabled;
		_rightAnswerButton.Disabled = isButtonDisabled;

		bool shouldHideButton = !(_currentQuestionIndex >= _quizQuestions.Length);

		_leftAnswerButton.Visible = shouldHideButton;
		_rightAnswerButton.Visible = shouldHideButton;
	}

	private void GoBack()
	{
		GetTree().ChangeSceneToFile(ScenesPath.GetPathFromId(ScenesPath.NodePathVariants.MainMenu));
	}
}
