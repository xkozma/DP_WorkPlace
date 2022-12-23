
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DeveloperZone
{
    public class TestAddCSharp: ScriptableObj
    {
        public Game game;
        private int level;

        // Update is called once per frame
        private void Update()
        {
            if (game != null) level = game.level;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (game != null && Regex.IsMatch(other.name, "Player", RegexOptions.IgnoreCase))
            {
                if (level < game.levels.Count)
                {
                    game.ShowLevel(level + 1);
                }
                else
                {
                    game.ShowLevel(level);
                }
            }
        }
    }
}
