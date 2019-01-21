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
    public enum SourceNumberTypeEnum
    {
        INTERNATIONAL, //TODO: Write general description for this method
        ALPHANUMERIC, //TODO: Write general description for this method
        SHORTCODE, //TODO: Write general description for this method
    }

    /// <summary>
    /// Helper for the enum type SourceNumberTypeEnum
    /// </summary>
    public static class SourceNumberTypeEnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "INTERNATIONAL", "ALPHANUMERIC", "SHORTCODE" };

        /// <summary>
        /// Converts a SourceNumberTypeEnum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The SourceNumberTypeEnum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(SourceNumberTypeEnum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case SourceNumberTypeEnum.INTERNATIONAL:
                case SourceNumberTypeEnum.ALPHANUMERIC:
                case SourceNumberTypeEnum.SHORTCODE:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of SourceNumberTypeEnum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of SourceNumberTypeEnum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<SourceNumberTypeEnum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into SourceNumberTypeEnum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed SourceNumberTypeEnum value</returns>
        public static SourceNumberTypeEnum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type SourceNumberTypeEnum", value));

            return (SourceNumberTypeEnum) index;
        }
    }
} 