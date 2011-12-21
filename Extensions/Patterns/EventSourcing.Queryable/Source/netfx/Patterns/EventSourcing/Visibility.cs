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
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

/***************************************
 * NOTE: feel free to change this file, 
 * that's intended. It will never be 
 * overwritten by NuGet updates later.
 **************************************/

// These are needed only if you include this package tests 
// or if you intend to mock any of the included types using 
// any of the proxy-generating mocking libraries such as 
// Moq, Rhino Mocks, etc.
// Otherwise, feel free to comment this out or wrap it in 
// an #if DEBUG directive.
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2,PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

// AggregateRoot is the only type that is public by default, as it's 
// likely that your domain model is public and therefore its base 
// class should too. This base class contains the implementation 
// to raise and load events into an aggregate root.
// Typically, in your own project you would derive from this 
// class your domain specific aggregate root class that provides 
// the types for both the id and base event, such as:
// public class AggregateRoot : AggregateRoot<Guid, DomainEvent> { }
public partial class AggregateRoot<TAggregateId, TBaseEvent> { }

// In order to make other types introduced by this package public, 
// declare a partial type as public here.
// For example, the following declarations would make everything public:

public partial interface IEventBus<TAggregateId, TBaseEvent> { }
public partial interface IEventHandler { }
public partial interface IEventHandler<TAggregateId, TEvent> { }
public partial interface IEventStore<TAggregateId, TBaseEvent> { }
public partial class EventQueryCriteria<TAggregateId> { }
public partial class EventQueryExtension { }

public partial class EventHandler<TAggregateId, TEvent> { }
public partial class EventBus<TAggregateId, TBaseEvent> { }