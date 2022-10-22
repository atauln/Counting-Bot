﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountVonCount
{
    internal class SimpleSerializer
    {
        private static readonly string path = ".conf";
        private static readonly Config defaultConfig = new()
        {
            Channel = "counting",
            WaitTimeSeconds = 3600,
            OkCountEmoji = "white_check_mark",
            BadCountEmoji = "x"
        };
        
        internal static (Config config, int highscore) ReadConfig()
        {
            Config config = new();
            int highscore = 0;
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                config.Channel = lines[0];
                config.WaitTimeSeconds = ulong.Parse(lines[1]);
                config.OkCountEmoji = lines[2];
                config.BadCountEmoji = lines[3];
                highscore = int.Parse(lines[4]);
            }
            else
                WriteConfig(defaultConfig, 0);

            return (config, highscore);
        }

        internal static void WriteConfig(Config config, int highscore)
        {
            File.WriteAllLines(path, new string[]
            {
                config.Channel!,
                config.WaitTimeSeconds?.ToString()!,
                config.OkCountEmoji!,
                config.BadCountEmoji!,
                highscore.ToString()
            });
        }
    }
}
