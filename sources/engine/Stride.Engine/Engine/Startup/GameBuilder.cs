// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Microsoft.Extensions.DependencyInjection;
using Stride.Games;

namespace Stride.Engine.Startup;

public class GameBuilder
{
    public ServiceCollection ServiceCollection { get; }


    public GameBuilder(ServiceCollection serviceCollection)
    {
        ServiceCollection = serviceCollection;
    }


    public GameRunner Build()
    {
        var serviceProvider = ServiceCollection.BuildServiceProvider();
        return new GameRunner(serviceProvider);
    }
}
