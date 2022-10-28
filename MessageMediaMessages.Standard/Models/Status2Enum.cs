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
    public enum Status2Enum
    {
        ENROUTE, //TODO: Write general description for this method
        FAILED, //TODO: Write general description for this method
        SUBMITTED, //TODO: Write general description for this method
        DELIVERED, //TODO: Write general description for this method
        EXPIRED, //TODO: Write general description for this method
        REJECTED, //TODO: Write general description for this method
        UNDELIVERABLE, //TODO: Write general description for this method
        HELD
    }

    /// <summary>
    /// Helper for the enum type Status2Enum
    /// </summary>
    public static class Status2EnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "enroute", "failed", "submitted", "delivered", "expired", "rejected", "undeliverable", "held" };

        /// <summary>
        /// Converts a Status2Enum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The Status2Enum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(Status2Enum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case Status2Enum.ENROUTE:
                case Status2Enum.FAILED:
                case Status2Enum.SUBMITTED:
                case Status2Enum.DELIVERED:
                case Status2Enum.EXPIRED:
                case Status2Enum.REJECTED:
                case Status2Enum.UNDELIVERABLE:
                case Status2Enum.HELD:    
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of Status2Enum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of Status2Enum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<Status2Enum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into Status2Enum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed Status2Enum value</returns>
        public static Status2Enum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type Status2Enum", value));

            return (Status2Enum) index;
        }
    }
} 