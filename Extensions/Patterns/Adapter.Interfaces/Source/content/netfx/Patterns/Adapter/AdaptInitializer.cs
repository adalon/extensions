﻿#region BSD License
/* 
Copyright (c) 2011, NETFx
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, 
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list 
  of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice, this 
  list of conditions and the following disclaimer in the documentation and/or other 
  materials provided with the distribution.

* Neither the name of Clarius Consulting nor the names of its contributors may be 
  used to endorse or promote products derived from this software without specific 
  prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES 
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH 
DAMAGE.
*/
#endregion

using System;
namespace NetFx.Patterns.Adapter
{
    /// <summary>
    /// Provides initialization for the <see cref="Adapt"/> class.
    /// </summary>
    /// <devdoc>
    /// Separating the initialization from the usage of the <see cref="Adapt"/>
    /// class allows consumers of the adapters to remain ignorant of how it's 
    /// initialized (can even be hidden at the API level by leaving this 
    /// class internal while making the <see cref="Adapt"/> type public.
    /// </devdoc>
    ///	<nuget id="netfx-Patterns.Adapter.Interfaces" />
    static partial class AdaptInitializer
    {
        /// <summary>
        /// Initializes the <see cref="Adapt"/> static facade with 
        /// the specified service.
        /// </summary>
        /// <param name="service">The adapter service to use on the <see cref="Adapt"/> class.</param>
        public static void Initialize(Lazy<IAdapterService> service)
        {
            Guard.NotNull(() => service, service);

            Adapt.Initialize(service);
        }
    }
}