// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Stride.Engine.Startup;

public class GameRunner
{
    public GameRunner(ServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }


    public ServiceProvider ServiceProvider { get; }


    public void Run()
    {
        var game = ServiceProvider.GetService<Game>();

        game.Run();

        ServiceProvider.Dispose();
    }
}
