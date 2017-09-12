﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.SignalR.Internal.Protocol;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.AspNetCore.SignalR.Client
{
    public static class HubConnectionBuilderExtensions
    {
        public static IHubConnectionBuilder WithHubProtocol(this IHubConnectionBuilder hubConnectionBuilder, IHubProtocol hubProtocol)
        {
            hubConnectionBuilder.AddSetting(HubConnectionBuilderDefaults.HubProtocolKey, hubProtocol);
            return hubConnectionBuilder;
        }

        public static IHubConnectionBuilder WithJsonProtocol(this IHubConnectionBuilder hubConnectionBuilder)
        {
            return hubConnectionBuilder.WithHubProtocol(new JsonHubProtocol(new JsonSerializer()));
        }

        public static IHubConnectionBuilder WithMessagePackProtocol(this IHubConnectionBuilder hubConnectionBuilder)
        {
            return hubConnectionBuilder.WithHubProtocol(new MessagePackHubProtocol());
        }

        public static IHubConnectionBuilder WithLogger(this IHubConnectionBuilder hubConnectionBuilder, ILoggerFactory loggerFactory)
        {
            hubConnectionBuilder.AddSetting(HubConnectionBuilderDefaults.LoggerFactoryKey, loggerFactory);
            return hubConnectionBuilder;
        }

        public static ILoggerFactory GetLoggerFactory(this IHubConnectionBuilder hubConnectionBuilder)
        {
            hubConnectionBuilder.TryGetSetting<ILoggerFactory>(HubConnectionBuilderDefaults.LoggerFactoryKey, out var loggerFactory);
            return loggerFactory;
        }

        public static IHubProtocol GetHubProtocol(this IHubConnectionBuilder hubConnectionBuilder)
        {
            hubConnectionBuilder.TryGetSetting<IHubProtocol>(HubConnectionBuilderDefaults.HubProtocolKey, out var hubProtocol);
            return hubProtocol;
        }
    }
}
