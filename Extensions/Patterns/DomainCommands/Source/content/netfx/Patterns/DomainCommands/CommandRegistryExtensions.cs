﻿#region BSD License
/* 
Copyright (c) 2010, NETFx
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

* Neither the name of Clarius Consulting nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion
using System;
using System.Collections.Generic;

/// <summary>
/// Adds usability overloads to <see cref="ICommandRegistry{TBaseCommand}"/>.
/// </summary>
static partial class CommandRegistryExtensions
{
	/// <summary>
	/// Executes the specified command with empty headers.
	/// </summary>
	/// <typeparam name="TBaseCommand">The base type that all commands inherit from, 
	/// or a common interface for all. Can even be <see cref="object"/> if no 
	/// common interface is needed.</typeparam>
	/// <param name="registry">The command registry to execute the command on.</param>
	/// <param name="command">The command to execute.</param>
	public static void Execute<TBaseCommand>(this ICommandRegistry<TBaseCommand> registry, TBaseCommand command)
	{
		Guard.NotNull(() => registry, registry);

		registry.Execute(command, new Dictionary<string, object>());
	}

	/// <summary>
	/// Executes the specified command.
	/// </summary>
	/// <typeparam name="TBaseCommand">The base type that all commands inherit from, 
	/// or a common interface for all. Can even be <see cref="object"/> if no 
	/// common interface is needed.</typeparam>
	/// <param name="registry">The command registry to execute the command on.</param>
	/// <param name="commands">The commands to execute.</param>
	public static void Execute<TBaseCommand>(this ICommandRegistry<TBaseCommand> registry, IEnumerable<TBaseCommand> commands)
	{
		Guard.NotNull(() => registry, registry);
		Guard.NotNull(() => commands, commands);

		foreach (var command in commands)
		{
			registry.Execute(command, new Dictionary<string, object>());
		}
	}

	/// <summary>
	/// Executes the specified command.
	/// </summary>
	/// <typeparam name="TBaseCommand">The base type that all commands inherit from, 
	/// or a common interface for all. Can even be <see cref="object"/> if no 
	/// common interface is needed.</typeparam>
	/// <param name="registry">The command registry to execute the command on.</param>
	/// <param name="commands">The commands to execute.</param>
	/// <param name="headers">The headers for the commands.</param>
	public static void Execute<TBaseCommand>(this ICommandRegistry<TBaseCommand> registry, IEnumerable<TBaseCommand> commands, IDictionary<string, object> headers)
	{
		Guard.NotNull(() => registry, registry);
		Guard.NotNull(() => commands, commands);
		Guard.NotNull(() => headers, headers);

		foreach (var command in commands)
		{
			registry.Execute(command, new Dictionary<string, object>(headers));
		}
	}
}
