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
    public enum StatusEnum
    {
        ENROUTE, //TODO: Write general description for this method
        SUBMITTED, //TODO: Write general description for this method
        DELIVERED, //TODO: Write general description for this method
        EXPIRED, //TODO: Write general description for this method
        REJECTED, //TODO: Write general description for this method
        UNDELIVERABLE, //TODO: Write general description for this method
        QUEUED, //TODO: Write general description for this method
        PROCESSED, //TODO: Write general description for this method
        CANCELLED, //TODO: Write general description for this method
        SCHEDULED, //TODO: Write general description for this method
        FAILED, //TODO: Write general description for this method
    }

    /// <summary>
    /// Helper for the enum type StatusEnum
    /// </summary>
    public static class StatusEnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "enroute", "submitted", "delivered", "expired", "rejected", "undeliverable", "queued", "processed", "cancelled", "scheduled", "failed" };

        /// <summary>
        /// Converts a StatusEnum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The StatusEnum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(StatusEnum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case StatusEnum.ENROUTE:
                case StatusEnum.SUBMITTED:
                case StatusEnum.DELIVERED:
                case StatusEnum.EXPIRED:
                case StatusEnum.REJECTED:
                case StatusEnum.UNDELIVERABLE:
                case StatusEnum.QUEUED:
                case StatusEnum.PROCESSED:
                case StatusEnum.CANCELLED:
                case StatusEnum.SCHEDULED:
                case StatusEnum.FAILED:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of StatusEnum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of StatusEnum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<StatusEnum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into StatusEnum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed StatusEnum value</returns>
        public static StatusEnum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type StatusEnum", value));

            return (StatusEnum) index;
        }
    }
} 