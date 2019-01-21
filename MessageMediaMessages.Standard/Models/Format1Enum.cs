/*
 * MessageMediaMessages.Standard
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MessageMedia.Messages;
using MessageMedia.Messages.Utilities;

namespace MessageMedia.Messages.Models
{
    [JsonConverter(typeof(StringValuedEnumConverter))]
    public enum Format1Enum
    {
        SMS, //TODO: Write general description for this method
        TTS, //TODO: Write general description for this method
        MMS, //TODO: Write general description for this method
    }

    /// <summary>
    /// Helper for the enum type Format1Enum
    /// </summary>
    public static class Format1EnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "SMS", "TTS", "MMS" };

        /// <summary>
        /// Converts a Format1Enum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The Format1Enum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(Format1Enum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case Format1Enum.SMS:
                case Format1Enum.TTS:
                case Format1Enum.MMS:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of Format1Enum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of Format1Enum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<Format1Enum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into Format1Enum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed Format1Enum value</returns>
        public static Format1Enum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type Format1Enum", value));

            return (Format1Enum) index;
        }
    }
} 