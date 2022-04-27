﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;

#if !NETCOREAPP
using Analyzer.Utilities.Extensions;
#endif

namespace Analyzer.Utilities
{
    internal static class HashUtilities
    {
        internal static int GetHashCodeOrDefault(this object? obj) => obj?.GetHashCode() ?? 0;

        internal static int Combine<T>(ImmutableArray<T> array)
        {
            var hashCode = new RoslynHashCode();
            Combine(array, ref hashCode);
            return hashCode.ToHashCode();
        }

        internal static void Combine<T>(ImmutableArray<T> array, ref RoslynHashCode hashCode)
        {
            foreach (var element in array)
            {
                hashCode.Add(element);
            }
        }

        internal static int Combine<T>(ImmutableStack<T> stack)
        {
            var hashCode = new RoslynHashCode();
            Combine(stack, ref hashCode);
            return hashCode.ToHashCode();
        }

        internal static void Combine<T>(ImmutableStack<T> stack, ref RoslynHashCode hashCode)
        {
            foreach (var element in stack)
            {
                hashCode.Add(element);
            }
        }

        internal static int Combine<T>(ImmutableHashSet<T> set)
        {
            var hashCode = new RoslynHashCode();
            Combine(set, ref hashCode);
            return hashCode.ToHashCode();
        }

        internal static void Combine<T>(ImmutableHashSet<T> set, ref RoslynHashCode hashCode)
        {
            foreach (var element in set)
            {
                hashCode.Add(element);
            }
        }

        internal static int Combine<TKey, TValue>(ImmutableDictionary<TKey, TValue> dictionary)
        {
            var hashCode = new RoslynHashCode();
            Combine(dictionary, ref hashCode);
            return hashCode.ToHashCode();
        }

        internal static void Combine<TKey, TValue>(ImmutableDictionary<TKey, TValue> dictionary, ref RoslynHashCode hashCode)
        {
            foreach (var (key, value) in dictionary)
            {
                hashCode.Add(key);
                hashCode.Add(value);
            }
        }
    }
}
