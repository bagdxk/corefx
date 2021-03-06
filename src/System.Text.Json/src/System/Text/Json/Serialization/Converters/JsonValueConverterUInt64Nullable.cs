﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization.Policies;

namespace System.Text.Json.Serialization.Converters
{
    internal sealed class JsonValueConverterUInt64Nullable : JsonValueConverter<ulong?>
    {
        public override bool TryRead(Type valueType, ref Utf8JsonReader reader, out ulong? value)
        {
            if (reader.TokenType != JsonTokenType.Number ||
                !reader.TryGetUInt64(out ulong rawValue))
            {
                value = default;
                return false;
            }

            value = rawValue;
            return true;
        }

        public override void Write(ulong? value, ref Utf8JsonWriter writer)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override void Write(Span<byte> escapedPropertyName, ulong? value, ref Utf8JsonWriter writer)
        {
            writer.WriteNumber(escapedPropertyName, value.Value);
        }
    }
}
