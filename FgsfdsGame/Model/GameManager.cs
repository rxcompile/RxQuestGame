#region

using System;

#endregion

namespace FgsfdsGame.Model
{
    public class GameManager : Singleton<GameManager>
    {
        private GameManager()
        {
            Screen = GetTest();
            Stats = new PlayerStats();
        }

        public GameScreen Screen { get; private set; }

        public PlayerStats Stats { get; private set; }

        public event EventHandler Update;

        private void OnUpdate()
        {
            EventHandler handler = Update;
            if (handler != null) handler(this, new EventArgs());
        }

        public void SetTarget(GameScreen target)
        {
            Screen = target;
            OnUpdate();
        }

        private GameScreen GetTest()
        {
            var q = new GameScreen
                        {
                            Description = "Hello!",
                            Image = "/FgsfdsGame;component/Resources/Images/HET_Psilocybid.jpg",
                            ToolTipInformation = "YAY!"
                        };
            var loop = new GameScreen
                           {Description = "Loop", Choices = new[] {new RedirectChoice {Name = "Back", Target = q}}};
            var bad = new GameScreen
                          {Description = "Bad", Choices = new[] {new RedirectChoice {Name = "Back", Target = q}}};
            q.Choices = new[]
                            {
                                new GameChoice {Name = "Choice1"},
                                new AnswerChoice
                                    {
                                        Name = "Answer",
                                        Question = "A?",
                                        RightAnswer = "A",
                                        Target = loop,
                                        WrongRedirect = bad
                                    },
                                new RedirectWithTimerRemove {Name = "RemoveCIA", Target = loop, Timer = "CIA"},
                                new RedirectWithTimerSet
                                    {Target = loop, Name = "TEST", Timer = "CIA", TimerTime = 15},
                                new ExitChoice {Name = "Exit"}
                            };
            return q;
        }
    }
}