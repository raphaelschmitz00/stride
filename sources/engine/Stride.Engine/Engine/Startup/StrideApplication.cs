// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Microsoft.Extensions.DependencyInjection;
using Stride.Audio;
using Stride.Core;
using Stride.Core.IO;
using Stride.Engine.Processors;
using Stride.Games;
using Stride.Profiling;
using Stride.Rendering.Fonts;
using Stride.Rendering.Sprites;
using Stride.Streaming;
using Stride.VirtualReality;

namespace Stride.Engine.Startup;

public class StrideApplication
{
    /// <summary>
    /// Creates a GameBuilder with the default functionality added.
    /// </summary>
    public static GameBuilder CreateBuilder()
    {
        var serviceCollection = new ServiceCollection();

        // ServiceRegistry
        serviceCollection.AddSingleton(serviceProvider =>
        {
            var serviceRegistry = new ServiceRegistry();
            
            serviceRegistry.AddService(serviceProvider.GetService<IDatabaseFileProviderService>());
            serviceRegistry.AddService(serviceProvider.GetService<IGameSystemCollection>());

            return serviceRegistry;
        });
        
        // Extracted from GameBase
        serviceCollection.AddSingleton<IDatabaseFileProviderService>(_ => new DatabaseFileProviderService(null));
        serviceCollection.AddSingleton<LaunchParameters>();
        serviceCollection.AddSingleton<GameSystemCollection>();
        serviceCollection.AddSingleton<IGameSystemCollection>(serviceProvider => serviceProvider.GetService<GameSystemCollection>());

        // Extracted from Game
        serviceCollection.AddSingleton<Game>();
        serviceCollection.AddSingleton<ScriptSystem>();
        serviceCollection.AddSingleton<SceneSystem>();
        serviceCollection.AddSingleton<StreamingManager>();
        serviceCollection.AddSingleton<AudioSystem>();
        serviceCollection.AddSingleton<GameFontSystem>();
        serviceCollection.AddSingleton<SpriteAnimationSystem>();
        serviceCollection.AddSingleton<DebugTextSystem>();
        serviceCollection.AddSingleton<GameProfilingSystem>();
        serviceCollection.AddSingleton<VRDeviceSystem>();

        return new GameBuilder(serviceCollection);
    }
}
