using System;
using System.Collections.Generic;
using Game.Engine.Skills;

namespace Game.Engine.Interactions
{
    // a special interaction used for fogetting skills
    // if you want a clear example of how to write your own interesting interaction, this is probably NOT the right place 
    // see Gymir and Hymir files instead

    [Serializable]
    class SkillForgetInteraction : PlayerInteraction
    {
        public SkillForgetInteraction(GameSession parentSession) : base(parentSession) 
        { 
            Name = "interaction0002";
            Enterable = false;
        }

        protected override void RunContent()
        {
            List<Skill> tmp = parentSession.currentPlayer.ListOfSkills;
            List<string> choices = new List<string>();
            foreach (Skill sk in tmp)
            {
                choices.Add(sk.ToString());
            }
            parentSession.SendText("\nDrinking from this fountain can help you forget about one of your skills.");
            if (choices.Count > 1)
            {
                choices.Add("Thank you, I've changed my mind");
                int a = parentSession.GetListBoxChoice(choices);
                if (a < choices.Count - 1) parentSession.currentPlayer.ListOfSkills.RemoveAt(a);
            }
            else parentSession.SendText("However, you only know one skill currently. Your mind is already calm and simple, so the fountain water will not change you.");
        }
    }
}
