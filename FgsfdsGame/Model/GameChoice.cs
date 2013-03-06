#region

using System;
using System.Linq;
using System.Windows;
using FgsfdsGame.Pages;

#endregion

namespace FgsfdsGame.Model
{
    [Serializable]
    public class GameChoice
    {
        public string Name { get; set; }

        public virtual void Process()
        {
            MessageBox.Show(string.Format("Выбрано {0}", Name));
        }
    }

    [Serializable]
    public class ExitChoice : GameChoice
    {
        public override void Process()
        {
            Application.Current.Shutdown();
        }
    }

    [Serializable]
    public class RedirectChoice : GameChoice
    {
        public GameScreen Target { get; set; }

        public override void Process()
        {
            GameManager.Instance.SetTarget(Target);
        }
    }

    [Serializable]
    public class RedirectWithTimerSet : RedirectChoice
    {
        public string Timer { get; set; }
        public int TimerTime { get; set; }

        public override void Process()
        {
            base.Process();
            var timer = GameManager.Instance.Stats.Timers.FirstOrDefault(t => t.Name == Timer);
            if(timer == null)
            {
                timer = new VisualTimer(TimerTime*1000) {Name = Timer};
                GameManager.Instance.Stats.Timers.Add(timer);
            }
            else
            {
                timer.Reset(TimerTime * 1000);
            }
        }
    }

    [Serializable]
    public class RedirectWithTimerRemove : RedirectChoice
    {
        public string Timer { get; set; }
        public int TimerTime { get; set; }

        public override void Process()
        {
            base.Process();
            var timer = GameManager.Instance.Stats.Timers.FirstOrDefault(t => t.Name == Timer);
            if (timer != null)
            {
                timer.Remove();
                GameManager.Instance.Stats.Timers.Remove(timer);
            }
        }
    }

    [Serializable]
    public class AnswerChoice : RedirectChoice
    {
        public string Question { get; set; }
        public string RightAnswer { get; set; }
        public GameScreen WrongRedirect { get; set; }

        public override void Process()
        {
            if(new AnswerDialog{RightAnswer = RightAnswer, Question = Question}.ShowDialog() == true)
                base.Process();
            else if(WrongRedirect != null)
                GameManager.Instance.SetTarget(WrongRedirect);
        }
    }
}