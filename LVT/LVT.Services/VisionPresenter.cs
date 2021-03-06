﻿using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class VisionPresenter : IVisionPresenter
    {
        private IGoalPresenter _gp;

        public VisionPresenter(IGoalPresenter gp = null)
        {
            _gp = gp ?? new GoalPresenter();

        }

        public string VisualizeToString(Vision vision, string parentNode = "")
        {
            string result = $"[{{ v:'{vision.NodeID}', f:'{vision.GetType().Name}<div style=\"font-style:italic\">{vision.Title}</div>'}}, '']";

            if (vision.Goals.Count() >= 1)
            {
                result = result + ", " + ProcessGoals(vision);
            };

            return $"[{result}]";
        }

        private string ProcessGoals(Vision vision)
        {
            IEnumerable<String> goalsStrings = vision.Goals.Select(goal => _gp.VisualizeToString(goal, vision.NodeID));

            return string.Join(", ", goalsStrings);
        }
    }
}


