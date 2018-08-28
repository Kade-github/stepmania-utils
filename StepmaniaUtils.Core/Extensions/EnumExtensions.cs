﻿using System;
using System.Linq;
using StepmaniaUtils.Enums;

namespace StepmaniaUtils.Extensions
{
    public static class EnumExtensions
    {
        public static SmFileAttribute ToAttribute(this string attr)
        {
            if (Enum.TryParse(attr, true, out SmFileAttribute result))
            {
                return result;
            }

            return SmFileAttribute.UNDEFINED;
        }

        //TODO: Is this needed? if so, add unit tests, otherwise remove (check Dedicab Utility)
        public static string ToStyleName(this PlayStyle style)
        {
            switch (style)
            {
                case PlayStyle.Single:
                    return "dance-single";
                case PlayStyle.Double:
                    return "dance-double";
                case PlayStyle.Couple:
                    return "dance-couple";
                case PlayStyle.Solo:
                    return "dance-solo";
                case PlayStyle.Lights:
                    return "lights-cabinet";
                default:
                    return string.Empty;
            }
        }

        public static PlayStyle ToStyleEnum(this string styleName)
        {
            styleName = styleName.Trim().TrimEnd(':');
            switch (styleName)
            {
                case "dance-single":
                    return PlayStyle.Single;
                case "dance-double":
                    return PlayStyle.Double;
                case "dance-couple":
                    return PlayStyle.Couple;
                case "dance-solo":
                    return PlayStyle.Solo;
                case "lights-cabinet":
                    return PlayStyle.Lights;
                default:
                    return PlayStyle.Undefined;
            }
        }

        public static SongDifficulty ToSongDifficultyEnum(this string difficultyName)
        {
            return
                Enum.GetValues(typeof(SongDifficulty))
                    .OfType<SongDifficulty>()
                    .SingleOrDefault(d => difficultyName.Contains(d.ToString()));
        }
    }
}